function ex1(arr){
    //let arr = [1 , 2 , "three", "for", 5, "six"];
    let temp = [];
    for(let i = 0; i<arr.length;i++){
        if (typeof(arr[i])=="number")
            temp.push(arr[i]);
}
return temp
}

function ex3(num){
    let arr = [];
    while (arr.length!=1){
        arr = [];
        while (num){
                arr.push(num%10);
                num = (num-num%10)/10;
        }
                //console.log(arr.length)
        for (let j = 0;j<arr.length;j++){
            num = num + arr[j];  
        }
        }
    return num;
}

function ex4(arr){
let count = 0;
for(let i = 0; i<arr.length-1;i++){
    for(let j = i+1; j<arr.length;j++){
        if(arr[i]+arr[j] == 5)
            count++;
    }
    
}
return count;
}

function ex5(){
s = "Fred:Corwill;Wilfred:Corwill;Barney:Tornbull;Betty:Tornbull;Bjon:Tornbull;Raphael:Corwill;Alfred:Corwill";
s = s.toUpperCase();
let arr = s.split(';');
let split = [];
for (let i = 0; i < arr.length;i++){
let a = arr[i].split(':')[0];
let b = arr[i].split(':')[1];
arr[i] = b+ ', ' +a;
}
arr.sort();
for (let i = 0; i < arr.length;i++)
console.log('('+arr[i]+')');
}

function ex2_new(word){
    let count = 0;
    for(let i = 0;i<word.length;i++){
        if (word[count]==word[i] && i!=count){
            i=-1;
            count++
        }    
}
return word[count];
}