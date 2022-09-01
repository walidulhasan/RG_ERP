$(function () {

    $("#btnChangePassword").click(function () {
        const CurrentPassword = $("#CurrentPassword").val();
        const NewPassword = $("#NewPassword").val();
        const ConfirmPassword = $("#ConfirmPassword").val();

        if (!CurrentPassword) {
            $.alert.open('warning', 'Password is not empty.');
            return
        }

        if (NewPassword != ConfirmPassword) {
            $.alert.open('warning', 'Password is not match.');
            return;
        }
        if (NewPassword == CurrentPassword) {
            $.alert.open('warning', 'Password is match with old password.');
            return;
        }
        var data = { CurrentPassword: CurrentPassword, NewPassword: NewPassword };
        HttpRequest.Ajax("POST", "/api/UserAuthentication/UserAccessAPI/ChangeUserPassword", data, PasswordChangesuccessCallBack, null, false);

    });

    function PasswordChangesuccessCallBack(result) {
        if (result.result == 1) {
            window.location.href = "/Identity/Account/LogOut";
        } else {
            $.alert.open('error', result.message);
        }
    }


});