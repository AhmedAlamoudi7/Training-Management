"use strict";

// Class definition
var KTModalNewTarget = function () {
	var submitButton;
	var cancelButton;
	var validator;
	var form;
	var modal;
	var modalEl;

	// Init form inputs
	var initForm = function () {
		var skills = new Tagify(form.querySelector('[name="tags"]'), {
			whitelist: ["Important", "Urgent", "High", "Medium", "Low"],
			maxTags: 15,
			dropdown: {
				maxItems: 15,           // <- mixumum allowed rendered suggestions
				enabled: 0,             // <- show suggestions on focus
				closeOnSelect: false    // <- do not hide the suggestions dropdown once an item has been selected
			}
		});
		skills.on("change", function () {
			// Revalidate the field when an option is chosen
			validator.revalidateField('tags');
		});

		// Due date. For more info, please visit the official plugin site: https://flatpickr.js.org/
		var dueDate = $(form.querySelector('[name="due_date"]'));
		dueDate.flatpickr({
			altInput: true,
			altFormat: "F j, Y",
			dateFormat: "Y-m-d",
		});

		// Team assign. For more info, plase visit the official plugin site: https://select2.org/
		$(form.querySelector('[name="team_assign"]')).on('change', function () {
			// Revalidate the field when an option is chosen
			validator.revalidateField('team_assign');
		});
	}

	// Handle form validation and submittion
	var handleForm = function () {
		// Stepper custom navigation

		// Init form validation rules. For more info check the FormValidation plugin's official documentation:https://formvalidation.io/
		validator = FormValidation.formValidation(
			form,
			{
				fields: {
					'tags': {
						validators: {
							notEmpty: {
								message: 'المهارات مطلوبة'
							}
						}
					},
					'title': {
						validators: {
							notEmpty: {
								message: 'عنوان الاستشارة مطلوبة'
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
					'due_date': {
						validators: {
							notEmpty: {
								message: 'التخصص مطلوب'
							}
						}
					},
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
		);
		function submitId() {
			let special = $('#specializationId option:selected').val();
			let skills = $("#skills").val();
			let AdvisorId = $("#idAdvisor").val();
			let advisorPerHoure = $("#advisorPerHoure").val();

			String(skills);
			let formData = new FormData();
			formData.append("Title", $("#title").val());
			formData.append("Date", $("#date").val());
			formData.append("ShortDescription", $("#shortdescription").val());
			formData.append("StartSession", $("#kt_datepicker_8").val());
			formData.append("EndSession", $("#kt_datepicker_9").val());
			formData.append("AdviserId", AdvisorId);
			formData.append("PerHoure", advisorPerHoure);
			formData.append("SpecializationId", special);
			formData.append("Skills", skills);
			$.ajax({
				type: 'POST',
				url: '/ProfileAccount/AccountProfileUsers/ConsultationRequest',
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
							confirmButtonText: "تمت الحجز , يجب اكمال الحجز بالدفع",
							customClass: {
								confirmButton: "btn btn-primary"
							}
						}).then(function (result) {
							if (result.isConfirmed) {
								formData.append("consultid", response.consultid);

								$.ajax({
									type: 'POST',
									url: '/ProfileAccount/AccountProfileUsers/Payment',
									//contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
									processData: false,
									contentType: false,
									data: formData,
									success: function (response2) {
										if (response2.success) {
											formData.append("consultid", response.consultid);

											//Swal.fire({
											//	text: response2.responseText,
											//	icon: "success",
											//	buttonsStyling: false,
											//	confirmButtonText: "تمت الحجز , يجب اكمال الحجز بالدفع",
											//	customClass: {
											//		confirmButton: "btn btn-primary"
											//	}
											//}).then(function (result) {
											//	if (result.isConfirmed) {
													window.location = response2.link;
											//	}
											//});
										} else {
											// DoSomethingElse()
											Swal.fire({
												text: response2.responseText,
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
		// Action buttons
		submitButton.addEventListener('click', function (e) {
			e.preventDefault();

			// Validate form before submit
			if (validator) {
				validator.validate().then(function (status) {
					console.log('validated!');

					if (status == 'Valid') {
						submitButton.setAttribute('data-kt-indicator', 'on');

						// Disable button to avoid multiple click 
						submitButton.disabled = true;

						setTimeout(function () {
							submitButton.removeAttribute('data-kt-indicator');

							// Enable button
							submitButton.disabled = false;

							// Show success message. For more info check the plugin's official documentation: https://sweetalert2.github.io/
							submitId();
						}, 2000);
					} else {
						// Show error message.
						Swal.fire({
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
			}
		});

		cancelButton.addEventListener('click', function (e) {
			e.preventDefault();

			Swal.fire({
				text: "هل أنت متأكد من إلغاء العملية?",
				icon: "warning",
				showCancelButton: true,
				buttonsStyling: false,
				confirmButtonText: "نعم أنا متأكد!",
				cancelButtonText: "لا , رجوع",
				customClass: {
					confirmButton: "btn btn-primary",
					cancelButton: "btn btn-active-light"
				}
			}).then(function (result) {
				if (result.value) {
					form.reset(); // Reset form	
					modal.hide(); // Hide modal				
				} else if (result.dismiss === 'cancel') {
					Swal.fire({
						text: "العملية لم تتم ‘إلغائها!.",
						icon: "error",
						buttonsStyling: false,
						confirmButtonText: "نعم لقد فهمت!",
						customClass: {
							confirmButton: "btn btn-primary",
						}
					});
				}
			});
		});
	}

	return {
		// Public functions
		init: function () {
			// Elements
			modalEl = document.querySelector('#kt_modal_new_target');

			if (!modalEl) {
				return;
			}

			modal = new bootstrap.Modal(modalEl);

			form = document.querySelector('#kt_modal_new_target_form');
			submitButton = document.getElementById('kt_modal_new_target_submit');
			cancelButton = document.getElementById('kt_modal_new_target_cancel');

			initForm();
			handleForm();
		}
	};
}();

// On document ready
KTUtil.onDOMContentLoaded(function () {
	KTModalNewTarget.init();
});