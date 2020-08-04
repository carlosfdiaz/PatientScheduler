// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function addDashesPhone(input) {

    var r = /(\D+)/g,
        npa = '',
        nxx = '',
        last4 = '';
    input.value = input.value.replace(r, '');
    npa = input.value.substr(0, 3);
    nxx = input.value.substr(3, 3);
    last4 = input.value.substr(6, 4);
    input.value = npa + '-' + nxx + '-' + last4;

}
//SSN input validation add dashes
function addDashesSSN(input) {

    var r = /(\D+)/g,
        npa = '',
        nxx = '',
        last4 = '';
    input.value = input.value.replace(r, '');
    npa = input.value.substr(0, 3);
    nxx = input.value.substr(3, 2);
    last4 = input.value.substr(5, 4);
    input.value = npa + '-' + nxx + '-' + last4;

}

var Phone = document.getElementById("Phone");
if (Phone !== null) {
    Phone.addEventListener("keyup", () => {
        addDashesPhone(Phone);
    });

}

var SSN = document.getElementById("SSN");
if (SSN !== null) {
    SSN.addEventListener("keyup", () => {
        addDashesSSN(SSN);
    });
}


