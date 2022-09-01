function buttonDisabled(thatButton, timers = 500) {
    debugger;
    let currentText = "";
    currentText = thatButton.text();

    var loadingText = `<span id='btn-wait-click'><span class="spinner-border spinner-border-sm text-danger" role="status" aria-hidden="true"></span>  <span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span>
  <span>Loading...</span></span>`;
    thatButton.html(loadingText);
    thatButton.prop('disabled', true);
    setTimeout(function () {
        thatButton.prop('disabled', false);
        $("#btn-wait-click").remove();
        thatButton.html(currentText);
    }, timers);
}


function ToProperCase(str) {
    if (str != null || str != "") {
        return str.replace(/\b\w/g, l => l.toUpperCase());
    }

}