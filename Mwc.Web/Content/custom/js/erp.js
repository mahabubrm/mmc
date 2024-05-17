
var IntelliERP = IntelliERP || {};

IntelliERP.SelectList = function () {

    Bind = function (ctrlId, data) {

        var option = '';
        for (var i = 0; i < data.length; i++) {
            option += '<option value="' + data[i].Value + '" >' + data[i].Text + '</option>';
        }
        $('#' + ctrlId).empty().append(option);
    };

    return {
        Bind: Bind
    }

}();

IntelliERP.Toastr = function () {
    Show = function (messageType, message, redirectUrl) {

        messageType = messageType.toString().toLowerCase();
        if (messageType == 'error' || messageType == '3') {
            toastr.error(message);
        }
        else if (messageType == 'success' || messageType == '1') {
            toastr.success(message);
        }        
        else if ((messageType == 'none' || messageType == '2' || messageType == 'warning') && message != '' && message != null) {
            toastr.warning(message);
        }
    };

    return {
        Show: Show
    };
}();

IntelliERP.Request = function () {
    Submit = function (url, isPost, parameters, needToStringify, successCallback) {
        var type = isPost == true ? 'POST' : 'GET';
        parameters = needToStringify == true ? JSON.stringify(parameters) : parameters;
        $.ajax({
            type: type,
            url: url,
            data: parameters,
            success: successCallback,
            error: function (xhr, textStatus, errorThrown) {
                console.log('error');
            }
        });
    };
    return {
        Submit: Submit
    };
}();



