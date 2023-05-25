"use strict";

// Class Definition
var KTSigninTwoSteps = function() {
    // Elements
    var form;
    var submitButton;

    // Handle form
    var handleForm = function (e) {     

        function submitId() {
            //var dataO = {
            //	firstName: $('#id="firstName').val()
            //};
            //var json = JSON2.stringify(dataO); 
            let data = $("#kt_sing_in_two_steps_form").serialize();
            let code_1 = $("#code_1").val();
            let code_2 = $("#code_2").val();
            let code_3 = $("#code_3").val();
            let code_4 = $("#code_4").val();
            let code_5 = $("#code_5").val();
            let code_6 = $("#code_6").val();
            let code = code_6 + code_5 + code_4 + code_3 + code_2 + code_1;
            let formData = new FormData();
            formData.append("userId", $("#user_id").val());
            formData.append("code", code);

            $.ajax({
                type: 'POST',
                url: '/ProfileAccount/AccountProfileUsers/ConfirmEmail',
                //contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
                processData: false,
                contentType: false,
                data: formData,
                success: function (response) {
                    if (response.success) {

                        Swal.fire({
                            text: response.responseText,
                            icon: "success",
                            buttonsStyling: false,
                            confirmButtonText: "تمت الاضافة",
                            customClass: {
                                confirmButton: "btn btn-primary"
                            }
                        }).then(function (result) {
                            if (result.isConfirmed) {
                                window.location.href = response.link;

                            }
                        });
                    } else {
                        // DoSomethingElse()
                        Swal.fire({
                            text: response.responseText,
                            icon: "error",
                            buttonsStyling: false,
                            confirmButtonText: "اعادة المحاولة",
                            customClass: {
                                confirmButton: "btn btn-primary"
                            }
                        });
                    };
                },
                error: function () {
                    Swal.fire({
                        text: "عذرا يوجد خطأ بالبيانات , الرجاء حاول مرة أخرى",
                        icon: "error",
                        buttonsStyling: false,
                        confirmButtonText: "اعادة المحاولة",
                        customClass: {
                            confirmButton: "btn btn-primary"
                        }
                    });
                }
            })
        }

        // Handle form submit
        submitButton.addEventListener('click', function (e) {
            e.preventDefault();

            var validated = true;

            var inputs = [].slice.call(form.querySelectorAll('input[maxlength="1"]'));
            inputs.map(function (input) {
                if (input.value === '' || input.value.length === 0) {
                    validated = false;
                }
            });

            if (validated === true) {
                // Show loading indication
                submitButton.setAttribute('data-kt-indicator', 'on');

                // Disable button to avoid multiple click 
                submitButton.disabled = true;

                // Simulate ajax request
                setTimeout(function() {
                    // Hide loading indication
                    submitButton.removeAttribute('data-kt-indicator');

                    // Enable button
                    submitButton.disabled = false;

                    //// Show message popup. For more info check the plugin's official documentation: https://sweetalert2.github.io/
                    //Swal.fire({
                    //    text: "لقد تم التحقق منك بنجاح!",
                    //    icon: "success",
                    //    buttonsStyling: false,
                    //    confirmButtonText: "حسنًا ، استمر!",
                    //    customClass: {
                    //        confirmButton: "btn btn-primary"
                    //    }
                    //}).then(function (result) {
                    //    if (result.isConfirmed) {



                    //    }
                    //});
                    submitId();
                }, 1000); 
            } else {
                swal.fire({
                    text: "الرجاء إدخال رمز أمان صالح وحاول مرة أخرى.",
                    icon: "error",
                    buttonsStyling: false,
                    confirmButtonText: "حسنًا ، استمر!",
                    customClass: {
                        confirmButton: "btn fw-bold btn-light-primary"
                    }
                }).then(function() {
                    KTUtil.scrollTop();
                });
            }
        });
    }

    var handleType = function() {
        var input1 = form.querySelector("[name=code_1]");
        var input2 = form.querySelector("[name=code_2]");
        var input3 = form.querySelector("[name=code_3]");
        var input4 = form.querySelector("[name=code_4]");
        var input5 = form.querySelector("[name=code_5]");
        var input6 = form.querySelector("[name=code_6]");

        input1.focus();

        input1.addEventListener("keyup", function() {
            if (this.value.length === 1) {
                input2.focus();
            }
        });

        input2.addEventListener("keyup", function() {
            if (this.value.length === 1) {
                input3.focus();
            }
        });

        input3.addEventListener("keyup", function() {
            if (this.value.length === 1) {
                input4.focus();
            }
        });

        input4.addEventListener("keyup", function() {
            if (this.value.length === 1) {
                input5.focus();
            }
        });

        input5.addEventListener("keyup", function() {
            if (this.value.length === 1) {
                input6.focus();
            }
        });
        
        input6.addEventListener("keyup", function() {
            if (this.value.length === 1) {
                input6.blur();
            }
        });
    }    

    // Public functions
    return {
        // Initialization
        init: function() {
            form = document.querySelector('#kt_sing_in_two_steps_form');
            submitButton = document.querySelector('#kt_sing_in_two_steps_submit');

            handleForm();
            handleType();
        }
    };
}();

// On document ready
KTUtil.onDOMContentLoaded(function() {
    KTSigninTwoSteps.init();
});