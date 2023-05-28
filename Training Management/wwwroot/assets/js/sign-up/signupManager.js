"use strict";

// Class definition
var KTSignupGeneral = function () {
    // Elements
    var form;
    var submitButton;
    var validator;
    var passwordMeter;

    // Handle form
    var handleForm = function (e) {
        // Init form validation rules. For more info check the FormValidation plugin's official documentation:https://formvalidation.io/
        validator = FormValidation.formValidation(
            form,
            {
                fields: {
                    'name': {
                        validators: {
                            notEmpty: {
                                message: 'الإسم  مطلوب'
                            }
                        }
                    },

                    'email': {
                        validators: {
                            regexp: {
                                regexp: /^[^\s@]+@[^\s@]+\.[^\s@]+$/,
                                message: 'القيمة ليست عنوان بريد إلكتروني صالحًا',
                            },
                            notEmpty: {
                                message: 'مطلوب عنوان البريد الإلكتروني'
                            }
                        }
                    },
                    'password': {
                        validators: {
                            notEmpty: {
                                message: 'كلمة المرور مطلوبة'
                            },
                            callback: {
                                message: 'الرجاء إدخال كلمة مرور صالحة',
                                callback: function (input) {
                                    if (input.value.length > 0) {
                                        return validatePassword();
                                    }
                                }
                            }
                        }
                    },
                    'confirmpassword': {
                        validators: {
                            notEmpty: {
                                message: 'مطلوب تأكيد كلمة المرور'
                            },
                            identical: {
                                compare: function () {
                                    return form.querySelector('[name="password"]').value;
                                },
                                message: 'كلمة المرور وتأكيدها ليسا متطابقين'
                            }
                        }
                    }, 'acceptterms': {
                        validators: {
                            notEmpty: {
                                message: 'الموافقة على الشروط مطلوبة'
                            }
                        }
                    },
                    'toc': {
                        validators: {
                            notEmpty: {
                                message: 'يجب عليك قبول الشروط والأحكام'
                            }
                        }
                    }
                },
                plugins: {
                    trigger: new FormValidation.plugins.Trigger({
                        event: {
                            password: false
                        }
                    }),
                    bootstrap: new FormValidation.plugins.Bootstrap5({
                        rowSelector: '.fv-row',
                        eleInvalidClass: '',  // comment to enable invalid state icons
                        eleValidClass: '' // comment to enable valid state icons
                    })
                }
            }
        );
        function submitId() {

             let formData = new FormData();
            formData.append("Name", $("#name").val());
            formData.append("Email", $("#email").val());
             formData.append("Password", $("#password").val());
            formData.append("ConfirmPassword", $("#confirmpassword").val());
            $.ajax({
                type: 'POST',
                url: '/ProfileAccount/Registeration/RegisterManager',
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
                                //	form.reset();
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

            validator.revalidateField('password');

            validator.validate().then(function (status) {
                if (status == 'Valid') {
                    // Show loading indication
                    submitButton.setAttribute('data-kt-indicator', 'on');

                    // Disable button to avoid multiple click 
                    submitButton.disabled = true;

                    // Simulate ajax request
                    setTimeout(function () {
                        // Hide loading indication
                        submitButton.removeAttribute('data-kt-indicator');
                        // Enable button
                        submitButton.disabled = false;
                        // Show message popup. For more info check the plugin's official documentation: https://sweetalert2.github.io/
                        Swal.fire({
                            text: "جاري التحقق من البيانات المدخلة ...!",
                            icon: "warning",
                            buttonsStyling: false,
                            confirmButtonText: "حسنًا ، تحقق!",
                            customClass: {
                                confirmButton: "btn btn-primary"
                            }
                        }).then(function (result) {
                            if (result.isConfirmed) {
                                //form.reset();  // reset form                    
                                //passwordMeter.reset();  // reset password meter
                                //form.submit();
                                submitId();


                            }
                        });
                         
                    }
                        , 1500);
                } else {
                    // Show error popup. For more info check the plugin's official documentation: https://sweetalert2.github.io/
                    Swal.fire({
                        text: "معذرة ، يبدو أنه تم اكتشاف بعض الأخطاء ، يرجى المحاولة مرة أخرى.",
                        icon: "error",
                        buttonsStyling: false,
                        confirmButtonText: "حسنًا ، استمر!",
                        customClass: {
                            confirmButton: "btn btn-primary"
                        }
                    });
                }
            });
        });

        // Handle password input
        form.querySelector('input[name="password"]').addEventListener('input', function () {
            if (this.value.length > 0) {
                validator.updateFieldStatus('password', 'NotValidated');
            }
        });
    }

    // Password input validation
    var validatePassword = function () {
        return (passwordMeter.getScore() === 100);
    }

    // Public functions
    return {
        // Initialization
        init: function () {
            // Elements
            form = document.querySelector('#kt_sign_up_form');
            submitButton = document.querySelector('#kt_sign_up_submit');
            passwordMeter = KTPasswordMeter.getInstance(form.querySelector('[data-kt-password-meter="true"]'));

            handleForm();
        }
    };
}();

// On document ready
KTUtil.onDOMContentLoaded(function () {
    KTSignupGeneral.init();
});
