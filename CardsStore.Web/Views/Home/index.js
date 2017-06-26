(function() {
	$(function() {
		$(".EditLink").click(function() {
			var cardId = $(this).attr("model-id");

			$("#EditContainer").load("/Home/ViewCard/" + cardId);
		});

		$("#AddNewButton").click(function () {
			$("#EditContainer").load("/Home/ViewCard");
		});

		$(".DeleteLink").click(function () {
			var cardId = $(this).attr("model-id");

			if (confirm("Are you sure to delete card?")) {
				$.ajax({
					url: "/Home/DeleteCard/" + cardId
				}).done(function () {
					location.href = "/Home/Index";
				});
			}
		});
	});
})()