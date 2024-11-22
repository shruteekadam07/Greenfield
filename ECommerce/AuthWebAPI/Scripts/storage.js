//local storage functionality
function onSetData() {
    if (typeof (Storage) !== "undefined") {

        //code for seession storage/local storage
        var txtEmail = document.getElementById("txtemail")
        var email = txtEmail.value;
        localStorage.setItem("useremail", email)
    } else {
        //sorry no web storage support
    }
}

function onGetData() {

    if (typeof (Storage) !== "undefined") {
        //code for session storage/local storage
        var lblResult = document.getElementById("lblresult");
        var result = localStorage.getItem("useremail");
        lblResult.innerHTML=result;

    } else {
        //sorry no web storage support
    }
}

function onSetObj() {
    if (typeof (Storage) !== "undefined") {
        //code for session storage/local storage
        let Firstname = document.getElementById("firstname").value;
        let Lastname = document.getElementById("lastname").value;
        let UAge = document.getElementById("age").value;
        var user = { 'Fname':Firstname, 'lname':Lastname, 'Age':UAge };
        sessionStorage.setItem("user", JSON.stringify(user));


    } else {
        //sorry no web storage support
    }
}
function onGetObj() {
    if (typeof (Storage) !== "undefined") {
        var obj = JSON.parse(sessionStorage.user);
        var lblResultfname = document.getElementById("lblresultfname");
        var lblResultlnameage = document.getElementById("lblresultfname");
        var lblResult = document.getElementById("lblresultage");

        lblResultfname.innerHTML = obj.Fname;
        lblResultfname.innerHTML = obj.Lname;
        lblResultfname.innerHTML = obj.UAge;


    }
    else {

    }
}