$(document).ready

    (

        () => {


            $("#btnregister").click(() => {

                var email = document.getElementById("email").value;

                var password = document.getElementById("password").value;

                var user = { 'email': email, 'password': password };

                var users = JSON.parse(localStorage.getItem('users')) || [];


                users.push(user);

                localStorage.setItem('users', JSON.stringify(users));

                console.log("User Registered");

            });

            $("#btnlogin").click(() => {

                var email = document.getElementById("email").value;

                var password = document.getElementById("password").value;

                // Retrieve the users array from localStorage (or an empty array if none exists)

                var users = JSON.parse(localStorage.getItem('users')) || [];

                // Flag to check if a match was found

                var userFound = false;

                // Iterate through users to check if the entered email and password match any stored user

                for (var i = 0; i < users.length; i++) {

                    if (users[i].email === email && users[i].password === password) {

                        userFound = true;

                        break;  // Stop searching once a match is found

                    }

                }

                // Display a message based on whether the user was found or not

                if (userFound) {

                    console.log("Login successful");

                    // Redirect or show a success message (for example, to a dashboard)

                    alert("Welcome");

                } else {

                    console.log("Invalid email or password");

                    // Show an error message (you can display this in the UI if needed)

                    alert("Invalid email or password. Please try again.");

                }



            });

        }

    );


