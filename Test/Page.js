const { Key } = require("selenium-webdriver")

class page {
    constructor(webdrv,drv,timeout = 9999){
    this.timeout = timeout;
    this.drv = drv;
    this.webdrv = webdrv;
    }
    async quit(){
        await this.drv.quit();
    }
    async get(url){
        await this.drv.get(url)
    }
    async getCurrentUrl(){
        return await this.drv.getCurrentUrl()
    }
    async wait(selector, elementName, timeout ){
        let result;
        await this.drv.wait(
            ()=>
                this.drv.findElement(selector).then(
                    (element)=>{
                        result = element;
                        return true;
                    },
                    (err)=>{
                        if (err.name === "NoSuchElementError"){
                            return false;
                        }
                        return true;
                    }
                    
                ),
            timeout,
            "Unable to find element: ${elementName}"
        );
        return result
    }
    async click(element,timeout = 9999){
        await this.drv.wait(
            this.webdrv.until.elementIsVisible(element),
            timeout
        );
        await this.drv.wait(
            this.webdrv.until.elementIsEnabled(element),
            timeout
        );

        await this.drv.executeScript("arguments[0].click();",element)
    }
    async insert(element,argument,timeout = 9999){
        await this.drv.wait(
            this.webdrv.until.elementIsVisible(element),
            timeout
        );
        await this.drv.wait(
            this.webdrv.until.elementIsEnabled(element),
            timeout
        );

        await element.sendKeys(argument)
    }

    async elementByXPath(xpath,timeout = 9999){
        const element = this.webdrv.By.xpath(xpath);
        const result = await this.wait(element,xpath,timeout);
        return result;
    }
    async insertByXPath(xpath,argument, timeout = 9999){
        const element = await this.elementByXPath(xpath, timeout);
        await this.click(element, timeout)
    }
    async clickByXPath(xpath, timeout = 9999){
        const element = await this.elementByXPath(xpath,timeout);
        await this.click(element, timeout)
    }

}
module.export = page;