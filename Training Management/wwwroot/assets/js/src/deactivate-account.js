"use strict";

// Class definition
var KTAccountSettingsDeactivateAccount = function () {
    // Private variables
    var form;
    var validation;
    var submitButton;
    var id = $('#userId').val();
    function submitId() {

        $.ajax({
            type: 'POST',
            url: '/ProfileAccount/AccountProfileUsers/ChangeActive',
            data: { id: id },
            success: function (result) {
                location.reload();
            },
            error: function () {
                alert('Failed to receive the Data');
            }
        })
    }
    // Private functions
    var initValidation = function () {
        // Init form validation rules. For more info check the FormValidation plugin's official documentation:https://formvalidation.io/
        validation = FormValidation.formValidation(
            form,
            {
                fields: {
                    deactivate: {
                        validators: {
                            notEmpty: {
                                message: 'Please check the box to deactivate your account'
                            }
                        }
                    }
                },
                plugins: {
                    trigger: new FormValidation.plugins.Trigger(),
                    submitButton: new FormValidation.plugins.SubmitButton(),
                    //defaultSubmit: new FormValidation.plugins.DefaultSubmit(), // Uncomment this line to enable normal button submit after form validation
                    bootstrap: new FormValidation.plugins.Bootstrap5({
                        rowSelector: '.fv-row',
                        eleInvalidClass: '',
                        eleValidClass: ''
                    })
                }
            }
        );
    }

    var handleForm = function () {
        submitButton.addEventListener('click', function (e) {
            e.preventDefault();

            validation.validate().then(function (status) {
                if (status == 'Valid') {

                    swal.fire({
                        text: "هل أنت متأكد ؟?",
                        icon: "warning",
                        buttonsStyling: false,
                        showDenyButton: true,
                        confirmButtonText: "نعم",
                        denyButtonText: 'لا',
                        customClass: {
                            confirmButton: "btn btn-light-primary",
                            denyButton: "btn btn-danger"
                        }
                    }).then((result) => {
                        if (result.isConfirmed) {
                            Swal.fire({
                                text: 'الحساب تم تعطيله.', 
                                icon: 'success',
                                confirmButtonText: "تم",
                                buttonsStyling: false,
                                customClass: {
                                    confirmButton: "btn btn-light-primary"
                                }
                            },
                            )
                            submitId();
                        } else if (result.isDenied) {
                            Swal.fire({
                                text: 'الحساب لم يتم تعطيله.', 
                                icon: 'info',
                                confirmButtonText: "تم",
                                buttonsStyling: false,
                                customClass: {
                                    confirmButton: "btn btn-light-primary"
                                }
                            })
                        }
                    });

                } else {
                    swal.fire({
                        text: "المعذرة , يوجد خطأ بالبيانات المدخلة",
                        icon: "error",
                        buttonsStyling: false,
                        confirmButtonText: "نعم لقد فهمت!",
                        customClass: {
                            confirmButton: "btn btn-light"
                        }
                    });
                }
            });
        });
    }

    // Public methods
    return {
        init: function () {
            form = document.querySelector('#kt_account_deactivate_form');

            if (!form) {
                return;
            }
            
            submitButton = document.querySelector('#kt_account_deactivate_account_submit');

            initValidation();
            handleForm();
        }
    }
}();

// On document ready
KTUtil.onDOMContentLoaded(function() {
    KTAccountSettingsDeactivateAccount.init();
});
