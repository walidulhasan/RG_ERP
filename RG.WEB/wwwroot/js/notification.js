"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/NotificationHub").build();

connection.on("ReceiveNotification", function (notifications) {

    let totalNotificationCount = 0;
    let detailNotification = ``;
    let notificationJson = JSON.parse(notifications);


    $.each(notificationJson, function (i, v) {
       
        totalNotificationCount += v.NotificationCount;
        detailNotification += `<div class="dropdown-divider"></div>
                                <a href=${v.ApprovalURL} class="dropdown-item text-sm">
                                    <i class="fas fa-envelope mr-2"></i>${v.NotificationType} <sup> ${v.NotificationCount}</sup>
                                </a>`;
    });
    detailNotification = `<span class="dropdown-item dropdown-header">${totalNotificationCount} Notifications</span>` + detailNotification;
    let currentTotalNotification = RtnNumber($('.currentNotificationNo').text());
    if (totalNotificationCount - currentTotalNotification > 0) {
        $('.mainHeaderNav').removeClass('navbar-white').addClass('navbar-warning');
    }
    if (totalNotificationCount == 0)
        $('.notificationBell').removeClass('text-red animated');
    else
        $('.notificationBell').addClass('text-red animated');

    $('.currentNotificationNo').text(totalNotificationCount);
    $('.currentNotificationInfo').html(detailNotification);
});

function connectionStart() {

    connection.start().then(function () {
        SendNotification();
    }).catch(function (err) {
        return console.error(err.toString());
    });
}

connection.onclose(connectionStart);

connectionStart();

function SendNotification() {
    connection.invoke("SendNotification", "AllGPNotification").catch(function (err) {
        return console.error(err.toString());
    });
}
