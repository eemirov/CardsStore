(function () {
	$(function () {
		$.validator.setDefaults({
			highlight: function (element) {
				$(element).closest('.form-group').addClass('has-error');
			},

			unhighlight: function (element) {
				$(element).closest('.form-group').removeClass('has-error');
			},
			errorElement: 'span',

			errorClass: 'control-label'
		});
	});
})()