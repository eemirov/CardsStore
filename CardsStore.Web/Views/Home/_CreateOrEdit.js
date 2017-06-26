(function () {
	$(function () {
		$("#Name").focus();

		$("#SaveButton").click(function () {
			if ($("#EditCard").valid()) {
				return true;
			};

			return false;
		});

		$(".CatItem").click(function() {
			$("#CategoryIds").val($("input[class=CatItem]:checked").map(
				function () {return this.value;}).get().join(","));
		});
	});
})()