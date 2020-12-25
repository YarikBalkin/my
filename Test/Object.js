const Рage = require("./Paje") 

class Object extends Page{
    Main_Page_URL = "https://www.epam.com/"
    Search_Button = "/html/body/div[2]/div[2]/div[1]/header/div/ul/li[3]/div/button"
    ContactUs_Button = "/html/body/div[2]/div[2]/div[1]/header/div/ul/li[1]/a"
    Logo_Button = "/html/body/div[2]/div[2]/div[1]/header/div/a/img"
    LinkedIn_Button = "/html/body/div[2]/div[3]/div[1]/footer/div/div[2]/ul[2]/li[1]/a"
    Menu_Button = "/html/body/div[2]/div[2]/div[1]/header/div/div/button"
    Language_Button = "/html/body/div[2]/div[2]/div[1]/header/div/ul/li[2]/div/button"
    Consult_Button = "/html/body/div[2]/main/div[1]/div[3]/section/div/div[1]/section/div/div/div/div[1]/a/div[2]/p"
    EPUM_Continuum_Button = "/html/body/div[2]/div[3]/div[1]/footer/div/div[1]/ul/li[1]/a/img"

    Search_Bar = "/html/body/div[2]/div[2]/div[1]/header/div/ul/li[3]/div/div/form/div/input"
    Menu_Search = "/html/body/div[2]/div[2]/div[1]/header/div/div/nav/ul/li[1]/a"
    Another_Language_Button = "/html/body/div[2]/div[2]/div[1]/header/div/ul/li[2]/div/nav/ul/li[3]/a"
    constructor(webdriver, driver, timeout = 5000){
        super(webdriver,driver,timeout);
    }
    async test1(){
        await this.get(this.Main_Page_URL);
        await this.clickByXPath(this.Search_Button);
        await this.insert(this.Search_Bar,"C++")
    }
    async test2(){
        await this.get(this.Main_Page_URL);
        await this.clickByXPath(this.ContactUs_Button);
        await this.getCurrentUrl();
    }
    async test3(){
        await this.get(this.Main_Page_URL);
        await this.clickByXPath(this.Logo_Button);
        await this.getCurrentUrl();
    }
    async test4(){
        await this.get(this.Main_Page_URL);
        await this.clickByXPath(this.LinkedIn_Button);
        await this.getCurrentUrl();
    }
    async test5(){
        await this.get(this.Main_Page_URL);
        await this.clickByXPath(this.Menu_Button);
        await this.clickByXPath(this.Menu_Search);
    }
    async test6(){
        await this.get(this.Main_Page_URL);
        await this.clickByXPath(this.Language_Button);
        await this.clickByXPath(this.Another_Language_Button);
    }
    async test7(){
        await this.get(this.Main_Page_URL);
        await this.clickByXPath(this.Consult_Button);
        await this.getCurrentUrl();
    }
    async test8(){
        await this.get(this.Main_Page_URL);
        await this.clickByXPath(this.EPUM_Continuum_Button);
        await this.getCurrentUrl();
    }

}