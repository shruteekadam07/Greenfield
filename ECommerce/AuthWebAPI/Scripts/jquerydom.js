$(document).ready(
    () => {
        console.log("document is initialized");

        $("#btnshow").click(() => {
            console.log("button Show is clicked....");
            $("#para").show();
        });


        $("#btnhide").click(() => {
            console.log("button  Hide is clicked....");
            $("#para").hide();
        });
    });