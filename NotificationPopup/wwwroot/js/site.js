const config = {
    endPointPath: '/api/Notify',
    getNotificationsPath: '/GetAll',
    addNotifyPath: '/AddNotify',
    countUnreadNotifyPath: '/CountUnRead',
    readNotifyPath: '/ReadNotify'
}



$(document).ready(() => {
    //Count unread notification
    const CountUnread = () => $.ajax({
        url: config.endPointPath + config.countUnreadNotifyPath, success: (count) => {
            if (count > 0) {
                $("#badge-notify").removeClass("visually-hidden");
            }
        }
    })

    // Load notifications
    const LoadNotification = () => $.ajax({
        url: config.endPointPath + config.getNotificationsPath, success: (response) => {
            $('#no-notify-msg').remove();
            let notify_list = ``;
            $.each(response, (index, notifi) => {
                let notifyHtml = ``;
                switch (notifi.type.toLowerCase().trim()) {
                    case 'alarm':
                        notifyHtml = `
                        <li id='notifi-${notifi.notify_Id}'>
                            <div class="d-flex gap-2 dropdown-item align-items-center py-1" style="cursor:pointer">
                                <i class="bi bi-alarm-fill fs-4 text-warning fs-4 "></i>
                                <p style="font-size:13.5px; margin:0;text-align:start" class="text-wrap">${notifi.msg}</p>
                            </div>
                        </li>`;
                        break;
                    case 'danger':
                        notifyHtml = `
                        <li id='notifi-${notifi.notify_Id}'>
                            <div class="d-flex gap-2 dropdown-item align-items-center py-1" style="cursor:pointer">
                                <i class="bi bi-exclamation-circle-fill fs-4 text-danger"></i>
                                <p style="font-size:13.5px; margin:0;text-align:start" class="text-wrap">${notifi.msg}</p>
                            </div>
                        </li>`
                        break;
                }
                notify_list += notifyHtml;
            })
            $('#notify-list').html(notify_list)
        }, complete: (response) => {
        }
    });

    // Get New Notifications
    const Initialize = () => {
        setInterval(() => {
            CountUnread();
            LoadNotification();
        }, 1500)
    }

    const ReadNotification = () => {
        $.ajax({
            url: config.endPointPath + config.readNotifyPath, type: 'PUT',
            success: () => {
                if (!$("#badge-notify").hasClass("visually-hidden"))
                    $("#badge-notify").addClass("visually-hidden")
            }
        })
    }

    Initialize();

    $("#btn-notify").on("click", () => {
        ReadNotification();
    })

    // Add Notify Event
    $("#add-notify-form").on('submit', (e) => {
        e.preventDefault();

        const msg = $('#notify-msg').val().trim();
        const type = $('#type-select').val().trim();
        const end_date = $('#end-date').val().trim();

        $.ajax({
            url: config.endPointPath + config.addNotifyPath,
            contentType: 'application/json',
            type: "POST",
            data: JSON.stringify({ msg, type, end_date }),
            beforeSend: () => {
                $('#btn-create-notify').addClass('disabled')
            },
            success: () => {
                window.location.href = '/';
            },
            complete: () => {
                $('#btn-create-notify').removeClass('disabled')
            }
        })
    })

})
