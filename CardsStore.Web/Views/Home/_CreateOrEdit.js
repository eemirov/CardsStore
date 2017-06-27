(function () {
	$(function () {
		$("#Name").focus();

		$("#SaveButton").click(function () {
			if ($("#EditCard").valid()) {
				return true;
			};

			return false;
		});
	});
})()