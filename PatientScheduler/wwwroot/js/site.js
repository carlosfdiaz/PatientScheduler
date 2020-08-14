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


var deleteInsuranceForm = document.getElementById("DeleteInsuranceForm");
var deleteInsuranceBtn = document.getElementById("DeleteInsuranceBtn");
if (deleteInsuranceBtn !== null && deleteInsuranceForm !== null) {
    deleteInsuranceBtn.addEventListener("click", () => {
        event.preventDefault();
        swal({
            title: "Are you sure?",
            text: "Once deleted, you will not be able to recover this patient's insurance info.",
            icon: "warning",
            buttons: true,
            dangerMode: true,
        })
            .then((willDelete) => {
                if (willDelete) {
                    deleteInsuranceForm.submit();
                } else {
                    swal.close();
                }
            });
    });
}

var deletePatientForm = document.getElementById("DeletePatientForm");
var deletePatientBtn = document.getElementById("DeletePatientBtn");
if (deletePatientBtn !== null && deletePatientForm !== null) {
    deletePatientBtn.addEventListener("click", () => {
        event.preventDefault();
        swal({
            title: "Are you sure?",
            text: "Once deleted, you will not be able to recover this patient's info.",
            icon: "warning",
            buttons: true,
            dangerMode: true,
        })
            .then((willDelete) => {
                if (willDelete) {
                    deletePatientForm.submit();
                } else {
                    swal.close();
                }
            });
    });
}



//Calendar Post Appointment
function PostAppointment() {
    let form = document.getElementById("AppointmentForm")
    console.log(form);
    let formData = new FormData(form);
    for (var key of formData.keys()) {
        console.log(key);
    }
    
    fetch('/User/Schedule/PostAppointment/', {
        method: 'post',
        body: new URLSearchParams(formData)
    })
        .then((response) => {
            return response.text();
        })
        .then((result) => {
            console.log(result);
        })
        
   
}