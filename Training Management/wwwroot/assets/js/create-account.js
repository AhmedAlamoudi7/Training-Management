"use strict";

// Class definition
var KTCreateAccount = function () {
	// Elements
	var modal;
	var modalEl;

	var stepper;
	var form;
	var formSubmitButton;
	var formContinueButton;

	// Variables
	var stepperObj;
	var validations = [];

	
	// Private Functions
	var initStepper = function () {
		// Initialize Stepper
		stepperObj = new KTStepper(stepper);
		var skills = new Tagify(form.querySelector('[name="skills"]'), {
			whitelist: ["Important", "Urgent", "High", "Medium", "Low"],
			maxTags: 5,
			dropdown: {
				maxItems: 15,           // <- mixumum allowed rendered suggestions
				enabled: 0,             // <- show suggestions on focus
				closeOnSelect: false    // <- do not hide the suggestions dropdown once an item has been selected
			}
		});
		skills.on("change", function () {
			// Revalidate the field when an option is chosen
			validator.revalidateField('skills');
		});
		// Stepper change event
		stepperObj.on('kt.stepper.changed', function (stepper) {
			if (stepperObj.getCurrentStepIndex() === 4) {
				formSubmitButton.classList.remove('d-none');
				formSubmitButton.classList.add('d-inline-block');
				formContinueButton.classList.add('d-none');
			} else if (stepperObj.getCurrentStepIndex() === 5) {
				formSubmitButton.classList.add('d-none');
				formContinueButton.classList.add('d-none');
			} else {
				formSubmitButton.classList.remove('d-inline-block');
				formSubmitButton.classList.remove('d-none');
				formContinueButton.classList.remove('d-none');
			}
		});

		// Validation before going to next page
		stepperObj.on('kt.stepper.next', function (stepper) {
			console.log('stepper.next');

			// Validate form before change stepper step
			var validator = validations[stepper.getCurrentStepIndex() - 1]; // get validator for currnt step

			if (validator) {
				validator.validate().then(function (status) {
					console.log('validated!');

					if (status == 'Valid') {
						stepper.goNext();

						KTUtil.scrollTop();
					} else {
						Swal.fire({
							text: " يوجد خطأ بالبيانات , الرجاء التأكد من البيانات المدخلة",
							icon: "error",
							buttonsStyling: false,
							confirmButtonText: "لقد فهمت!",
							customClass: {
								confirmButton: "btn btn-light"
							}
						}).then(function () {
							KTUtil.scrollTop();
						});
					}
				});
			} else {
				stepper.goNext();

				KTUtil.scrollTop();
			}
		});

		// Prev event
		stepperObj.on('kt.stepper.previous', function (stepper) {
			console.log('stepper.previous');

			stepper.goPrevious();
			KTUtil.scrollTop();
		});

	}
	function submitId() {
		
		let special = $('#specializationId option:selected').val();
		let degree = $('#degreeId option:selected').val();
		let advisor_type = $('#advisor_type option:selected').val();
		let country = $('#kt_ecommerce_select2_country option:selected').val();
		let expert_type = $('#expert_type option:selected').val();
		let skills = $("#skills").val();
		let accept_term = $('#accept_terms').val();
		String(skills);
		let formData = new FormData();
		formData.append("CV", $("#cv")[0].files[0]);
		formData.append("FirstName", $("#first_name").val());
		formData.append("LastName", $("#last_name").val());
		formData.append("Email", $("#email").val());
		formData.append("Phone", $("#phone").val());
		formData.append("AdvisorType", advisor_type);
		formData.append("DegreeId", degree);
		formData.append("SpecializationId", special);
		formData.append("Skills", skills);
		formData.append("Password", $("#password").val());
		formData.append("ConfirmPassword", $("#confirmpassword").val());
		formData.append("Country", country);
		formData.append("ExpertType", expert_type);
		formData.append("Note", $("#Note").val());
		formData.append("Accept_terms", accept_term);

		$.ajax({
			type: 'POST',
			url: '/ProfileAccount/AccountProfileUsers/RegisterAdvisor',
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
	var handleForm = function () {
		formSubmitButton.addEventListener('click', function (e) {
			// Validate form before change stepper step
			var validator = validations[3]; // get validator for last form

			validator.validate().then(function (status) {
				console.log('validated!');

				if (status == 'Valid') {
					// Prevent default button action
					e.preventDefault();

					// Disable button to avoid multiple click 
					formSubmitButton.disabled = true;

					// Show loading indication
					formSubmitButton.setAttribute('data-kt-indicator', 'on');

					// Simulate form submission
					setTimeout(function () {
						// Hide loading indication
						formSubmitButton.removeAttribute('data-kt-indicator');

						// Enable button
						formSubmitButton.disabled = false;
						submitId();
					}, 2000);
				} else {
					Swal.fire({
						text: "عذرا , يوجد خطأ بالبيانات",
						icon: "خطأ",
						buttonsStyling: false,
						confirmButtonText: "نعم ,لقد فهمت!",
						customClass: {
							confirmButton: "btn btn-light"
						}
					}).then(function () {
						KTUtil.scrollTop();
					});
				}
			});
		});

		// Expiry month. For more info, plase visit the official plugin site: https://select2.org/
		$(form.querySelector('[name="card_expiry_month"]')).on('change', function () {
			// Revalidate the field when an option is chosen
			validations[3].revalidateField('card_expiry_month');
		});

		// Expiry year. For more info, plase visit the official plugin site: https://select2.org/
		$(form.querySelector('[name="card_expiry_year"]')).on('change', function () {
			// Revalidate the field when an option is chosen
			validations[3].revalidateField('card_expiry_year');
		});

		// Expiry year. For more info, plase visit the official plugin site: https://select2.org/
		$(form.querySelector('[name="business_type"]')).on('change', function () {
			// Revalidate the field when an option is chosen
			validations[2].revalidateField('business_type');
		});
	}

	var initValidation = function () {
		// Init form validation rules. For more info check the FormValidation plugin's official documentation:https://formvalidation.io/
		// Step 1
		validations.push(FormValidation.formValidation(
			form,
			{
				fields: {
					'first_name': {
						validators: {
							notEmpty: {
								message: 'الاسم الاول مطلوب'
							}
						}
					}, 'last_name': {
						validators: {
							notEmpty: {
								message: 'الاسم الاخير مطلوب'
							}
						}
					}, 'phone': {
						validators: {
							regexp: {
								regexp: /^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$/,
								message: '05XXXXXXX or 05XXXXXXX  الرجاء ادخال رقم موبايل صحيح',
							},
							notEmpty: {
								message: 'رقم الهاتف مطلوب'
							}
						}
					}, 'email': {
						validators: {
							regexp: {
								regexp: /^[^\s@]+@[^\s@]+\.[^\s@]+$/,
								message: 'القيمة ليست عنوان بريد إلكتروني صالحًا',
							},
							notEmpty: {
								message: 'البريد الالكتروني مطلوب'
							}
						}
					}, 'advisor_type': {
						validators: {
							notEmpty: {
								message: 'نوع الحساب مطلوب'
							}
						}
					}
				},
				plugins: {
					trigger: new FormValidation.plugins.Trigger(),
					bootstrap: new FormValidation.plugins.Bootstrap5({
						rowSelector: '.fv-row',
						eleInvalidClass: '',
						eleValidClass: ''
					})
				}
			}
		));

		// Step 2
		validations.push(FormValidation.formValidation(
			form,
			{
				fields: {
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
					},
					'cv': {
						validators: {
							notEmpty: {
								message: 'السيرة الذاتية مطلوبة'
							}
						}
					},
					'specializationId': {
						validators: {
							notEmpty: {
								message: 'التخصص مطلوب'
							}
						}
					},
					'degreeId': {
						validators: {
							notEmpty: {
								message: 'الدرجة العلمية مطلوبة'
							}
						}
					}
				},
				plugins: {
					trigger: new FormValidation.plugins.Trigger(),
					// Bootstrap Framework Integration
					bootstrap: new FormValidation.plugins.Bootstrap5({
						rowSelector: '.fv-row',
						eleInvalidClass: '',
						eleValidClass: ''
					})
				}
			}
		));

		// Step 3
		validations.push(FormValidation.formValidation(
			form,
			{
				fields: {
					'country': {
						validators: {
							notEmpty: {
								message: 'الدولة مطلوبة'
							}
						}
					},
					'skills': {
						validators: {
							notEmpty: {
								message: 'المهارات مطلوبة'
							}
						}
					},
					'expert_type': {
						validators: {
							notEmpty: {
								message: 'سنوات الخبرة مطلوبة'
							}
						}
					}, 'accept_terms': {
						validators: {
							notEmpty: {
								message: 'الموافقة على الشروط مطلوبة'
							}
						}
					}				
				},
				plugins: {
					trigger: new FormValidation.plugins.Trigger(),
					// Bootstrap Framework Integration
					bootstrap: new FormValidation.plugins.Bootstrap5({
						rowSelector: '.fv-row',
						eleInvalidClass: '',
						eleValidClass: ''
					})
				}
			}
		));

		// Step 4
		validations.push(FormValidation.formValidation(
			form,
			{
				plugins: {
					trigger: new FormValidation.plugins.Trigger(),
					// Bootstrap Framework Integration
					bootstrap: new FormValidation.plugins.Bootstrap5({
						rowSelector: '.fv-row',
						eleInvalidClass: '',
						eleValidClass: ''
					})
				}
			}
		));
	}
	// Init Select2 with flags
	const initSelect2Flags = () => {
		// Format options
		var optionFormat = function (item) {
			if (!item.id) {
				return item.text;
			}

			var span = document.createElement('span');
			var template = '';

			template += '<img src="' + item.element.getAttribute('data-kt-select2-country') + '" class="rounded-circle me-2" style="height:19px;" alt="image"/>';
			template += item.text;

			span.innerHTML = template;

			return $(span);
		}

		// Init Select2 --- more info: https://select2.org/
		$('[data-kt-ecommerce-settings-type="select2_flags"]').select2({
			placeholder: "Select a country",
			minimumResultsForSearch: Infinity,
			templateSelection: optionFormat,
			templateResult: optionFormat
		});
	}

	return {
		// Public Functions
		init: function () {
			// Elements
			modalEl = document.querySelector('#kt_modal_create_account');

			if (modalEl) {
				modal = new bootstrap.Modal(modalEl);
			}

			stepper = document.querySelector('#kt_create_account_stepper');

			if (!stepper) {
				return;
			}
		
			form = stepper.querySelector('#kt_create_account_form');
			formSubmitButton = stepper.querySelector('[data-kt-stepper-action="submit"]');
			formContinueButton = stepper.querySelector('[data-kt-stepper-action="next"]');

			initStepper();
			initValidation();
			handleForm();
			initSelect2Flags();
		}
	};
}();

// On document ready
KTUtil.onDOMContentLoaded(function () {
	KTCreateAccount.init();
});
