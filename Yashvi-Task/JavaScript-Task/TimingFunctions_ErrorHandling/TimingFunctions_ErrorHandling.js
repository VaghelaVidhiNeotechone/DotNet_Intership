 try{
            allert("Welcome");
        }
        catch(err){
            document.getElementById("demo").innerHTML=err.message;
        }


        function myfunction(){
            const message=document.getElementById("P01");
            message.innerHTML="";
            let x=document.getElementById("demo2").value;
            try{

                if(x.trim()=="")throw " empty";  
                if(isNaN(x)) throw " not a number";
                x=Number(x);
                if(x<5) throw " too low";
                if(x>10) throw " too high";
            }
            catch(err){ 
                message.innerHTML="Input is"+err;
            }
        }