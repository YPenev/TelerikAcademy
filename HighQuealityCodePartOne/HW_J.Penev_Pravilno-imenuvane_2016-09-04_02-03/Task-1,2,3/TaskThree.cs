function _ClickON_RequestButton(events, arguments)
{
    var openWindow = window,
        usedBrowser = openWindow.navigator.appCodeName,
        isUsedBrowserMozila = usedBrowser == "Mozilla";

    if (isUsedBrowserMozila)
    {
        alert("Yes");
    }
    else
    {
        alert("No");
    }
}