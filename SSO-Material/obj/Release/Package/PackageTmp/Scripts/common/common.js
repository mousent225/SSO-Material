function SetHeight(element, value) {
    element.css({
        height: value,
        "max-height": value,
        overflow: "auto"
    });
}

function showNotification(feeownTitle, feeownMess, feeownStyle) {
    //STYLE:   smokey, gray, osx, simple    
    //OPTION: autoHide_bool, autoHideDelay_int_ms, classes_array, prepend_bool
    var title = feeownTitle;
    var message = feeownMess;
    var opts = {};
    opts.classes = [feeownStyle]; //style
    opts.prepend = false;
    opts.autoHide = true;
    var container = '#freeow-tr';
    opts.classes.push("slide");
    opts.hideStyle = {
        opacity: 0,
        left: "400px"
    };
    opts.showStyle = {
        opacity: 1.5,
        left: 0
    };
    $(container).freeow(title, message, opts);
}

function confirmDelete() {
    return confirm('Bạn có thật sự muốn xóa đi dữ liệu này không?');
}

//check empty, conflict
function fnCheckEmpty($element, mess) {
    if ($element.val() === "") {
        showNotification("Hyosung Portal", mess, "gray error");
        $element.focus();
        return false;
    }
    return true;
}