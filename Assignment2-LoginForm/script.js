const usernameError="Username must be beween 3 and 25 characters"
const passwordError="Password must be atleast 8 characters that include at \
least 1 lowercase character, 1 uppercase character, 1 number and 1 special character\
 in (!@#$%^&*)."
const confirmPasswordError="Please enter the password again"

function checkNum(s){
    for(let c of s){
        if(c>='0' && c<='9'){
            return true;
        }
    }
    return false;
}
function checkSpecial(s){
    for(let c of s){
        if(c=='!' || c=='@' || c=='#' || c=='$' || c=='%' || c=='^' || c=='&' || c=='*'){
            return true;
        }
    }
    return false;
}

function togglePassword(){
    const password=document.getElementById("password");
    if(password.type==="password"){
        password.type="text";
        document.getElementById("passwordEye").src="./eye-regular.svg";
    }
    else{
        password.type="password";
        document.getElementById("passwordEye").src="./eye-slash-regular.svg";
    }
}
function toggleConfirmPassword(){
    const confirmPassword=document.getElementById("confirmPassword");
    if(confirmPassword.type==="password"){
        confirmPassword.type="text";
        document.getElementById("confirmPasswordEye").src="./eye-regular.svg";
    }
    else{
        confirmPassword.type="password";
        document.getElementById("confirmPasswordEye").src="./eye-slash-regular.svg";
    }
}

function checkUsername(){
    const value=document.getElementById("username").value;
    if(value.length<3 || value.length>25){
        document.getElementById("usernameError").innerText=usernameError
        document.getElementById('username').style.border="1px solid red";
        return false;
    }
    else{
        document.getElementById("usernameError").innerText=""
        document.getElementById('username').style.border="1px solid black";
        return true;
    }
}

function checkPassword(){
    const value=document.getElementById("password").value;
    if(value.length<8
        || value==value.toLowerCase()
        || value==value.toUpperCase()
        || !checkNum(value)
        || !checkSpecial(value)
    ){
        document.getElementById("passwordError").innerText=passwordError
        return false;
    }
    else{
        document.getElementById("passwordError").innerText=""
        return true;
    }
}

function checkConfirmPassword(){
    const value=document.getElementById("confirmPassword").value;
    console.log('something');
    if(value=='' || value!=document.getElementById("password").value){
        document.getElementById("confirmPasswordError").innerText=confirmPasswordError
        return false;
    }
    else{
        document.getElementById("confirmPasswordError").innerText=""
        return true
    }
}

function checkEmail(){
    const value=document.getElementById("email").value;
    if(value.length==0 || !value.includes('@')){
        document.getElementById("emailError").innerText="Please enter your correct email"
        return false;
    }
    else{
        document.getElementById("emailError").innerText=""
        return true;
    }
}

function handleSubmit(e){
    console.log("Form Submitted")
    e.preventDefault();
    if(checkUsername() & checkEmail() & checkPassword() & checkConfirmPassword() ){
        alert("You are Signed Up")
    }
}