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
        var result = GeneralGenericUtilities.callajaxReturnSuccess(
            "/api/Influencer/RegisterInfluencer",
            "POST",
            JSON.stringify(Model)
        );
        result.then(function (response) {
            console.log(response);
            GeneralGenericUtilities.ajaxindicatorstop();
        })

    },
}