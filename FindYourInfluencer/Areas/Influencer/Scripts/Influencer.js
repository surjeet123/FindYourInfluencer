$(document).ready(function () {
    $("#btnSaveNewInfluencer").click(function () {
        InfluencerUtilities.SaveNewInfluencer();
    })
});

InfluencerUtilities = {
    SaveNewInfluencer: function () {
        var Model = {};
        Model.FirstName = $("#txtInfluencerFirstName").val();
        Model.LastName = $("#txtInfluencerLastName").val();
        Model.EmailAddress = $("#txtInfluencerEmail").val();
        Model.MobileNo = $("#txtInfluencerMobile").val();
        Model.Password = $("#txtInfluencerPassword").val();
        var result = GeneralGenericUtilities.callajaxReturnSuccess("/Influencer/InfluencerRegistration", "POST",
            Model, true);
        result.then(function (response) {
            if (response && response.message) {

                alert(response.message);

                if (response.message === "Influencer registered successfully") {
                    // Optionally, redirect or perform other actions on success
                    // window.location.href = '/some/other/page';
                }
            } else {
                alert("An unexpected error occurred.");
            }
            GeneralGenericUtilities.ajaxindicatorstop();
        })

    },
}