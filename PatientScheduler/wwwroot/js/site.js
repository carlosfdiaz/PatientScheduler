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

//Alert for Deleting Insurance Information in PatientPage
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

//Alert for Deleting Patient Record in PatientPage
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

//Alert for Deleting Appointment in PatientPage
/*var deleteAppointmentForm = document.getElementById("DeleteAppointmentForm");
var deleteAppointmentBtn = document.getElementById("DeleteAppointmentBtn");
if (deleteAppointmentBtn !== null && deleteAppointmentForm !== null) {
    deleteAppointmentBtn.addEventListener("click", () => {
        event.preventDefault();
        swal({
            title: "Are you sure you want to delete this appointment?",
            text: "Once deleted, you will not be able to recover this apppointment.",
            icon: "warning",
            buttons: true,
            dangerMode: true,
        })
            .then((willDelete) => {
                if (willDelete) {
                    deleteAppointmentForm.submit();
                } else {
                    swal.close();
                }
            });
    });
}*/

//Alert for Marking Appointment as Completed in PatientPage
/*var markAppointmentCompleteForm = document.getElementById("MarkAppointmentCompleteForm");
var markAppointmentCompleteBtn = document.getElementById("MarkAppointmentCompleteBtn");
if (markAppointmentCompleteBtn !== null && markAppointmentCompleteForm !== null) {
    markAppointmentCompleteBtn.addEventListener("click", () => {
        event.preventDefault();
        swal({
            title: "Do you want to mark this appointment as Complete?",
            icon: "info",
            buttons: {
                cancel: "No, Go Back",             
                confirm: "Yes, Mark Complete",               
            },
        })
            .then((willDelete) => {
                if (willDelete) {
                    markAppointmentCompleteForm.submit();
                } else {
                    swal.close();
                }
            });
    });
}*/



//Alerts for Delete Appointment buttons in Patient Page
var deleteAppointmentBtns = document.getElementsByName("DeleteAppointmentBtn");
var deleteAppointmentForms = document.getElementsByName("DeleteAppointmentForm")
var i;
if (deleteAppointmentBtns !== null && deleteAppointmentForms !== null) {
    for (i = 0; i < deleteAppointmentBtns.length; i++) {           
        let cc = i;
        console.log(cc);
        deleteAppointmentBtns[i].addEventListener("click", () => {
            event.preventDefault();
            swal({
                title: "Are you sure you want to delete this appointment?",
                text: "Once deleted, you will not be able to recover this apppointment.",
                icon: "warning",
                buttons: true,
                dangerMode: true,
            })
                .then((willDelete) => {
                    if (willDelete) {                        
                        deleteAppointmentForms[cc].submit();

                    } else {
                        swal.close();
                    }
                });
        });

    }
}

//Alerts for Mark Appointment Complete buttons in Patient Page
var markAppointmentCompleteBtns = document.getElementsByName("MarkAppointmentCompleteBtn");
var markAppointmentCompleteForms = document.getElementsByName("MarkAppointmentCompleteForm")
var i;
if (markAppointmentCompleteBtns !== null && markAppointmentCompleteForms !== null) {
    for (i = 0; i < markAppointmentCompleteBtns.length; i++) {
        let cc = i;
        markAppointmentCompleteBtns[i].addEventListener("click", () => {
            event.preventDefault();
            swal({
                title: "Do you want to mark this appointment as Complete?",
                icon: "info",
                buttons: {
                    cancel: "No, Go Back",
                    confirm: "Yes, Mark Complete",
                },
            })
                .then((willDelete) => {
                    if (willDelete) {
                        console.log(cc);
                        markAppointmentCompleteForms[cc].submit();

                    } else {
                        swal.close();
                    }
                });
        });

    }
}

var markAppointmentCancelledBtns = document.getElementsByName("MarkAppointmentCancelledBtn");
var markAppointmentCancelledForms = document.getElementsByName("MarkAppointmentCancelledForm")
var i;
if (markAppointmentCancelledBtns !== null && markAppointmentCancelledForms !== null) {
    for (i = 0; i < markAppointmentCancelledBtns.length; i++) {
        let cc = i;
        markAppointmentCancelledBtns[i].addEventListener("click", () => {
            event.preventDefault();
            swal({
                title: "Do you want to mark this appointment as Cancelled?",
                icon: "info",
                buttons: {
                    cancel: "No, Go Back",
                    confirm: "Yes, Mark Cancelled",
                },
            })
                .then((willDelete) => {
                    if (willDelete) {
                        console.log(cc);
                        markAppointmentCancelledForms[cc].submit();

                    } else {
                        swal.close();
                    }
                });
        });

    }
}

//Calendar Post Appointment
function PostAppointment() {
    let form = document.getElementById("AppointmentForm")
    console.log(form);
    let formData = new FormData(form);
    console.log(formData.get("Appointment.StartTime"));
    for (var key of formData.keys()) {
        console.log(key);
    }
    console.log(formData.get("Appointment.StartTime") + "START IN FETCH");
    console.log(formData.get("Appointment.EndTime") + "END IN FETCH");
   
    
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

