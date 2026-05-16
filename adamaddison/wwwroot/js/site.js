let showPopoutMenu = false;

const Theme = Object.freeze({
    light: 0,
    dark: 1
});

let appTheme = Theme.light;
let appAutoTheme = true;

function togglePopoutMenu()
{
    showPopoutMenu = !showPopoutMenu;
    showPopoutMenu ? $('#menuBarMobilePopout').addClass('showMenuBarMobilePopout')
                   : $('#menuBarMobilePopout').removeClass('showMenuBarMobilePopout');
    showPopoutMenu ? $('#menuBarMobilePopoutBackground').addClass('opacityFull')
                   : $('#menuBarMobilePopoutBackground').removeClass('opacityFull');
}

function openProjectFullscreen(projectIndex)
{
    $(".projectWindow").eq(projectIndex).addClass("opacityFull");
    $("#projectWindowGreyedOutBackground").addClass("opacityFull");
}
function closeProjectFullscreen()
{
    $(".projectWindow").removeClass("opacityFull");
    $("#projectWindowGreyedOutBackground").removeClass("opacityFull");
}

// Making the first organisation info visible / selected on load for desktop
$(document).ready(function(){
    $('.organisationContentGrid').eq(0).addClass('displayIsBlock');
    $('.appSelectListItem').eq(0).addClass('appListItemSelected');
});

function selectOrganisation(index)
{
    $('.organisationContentGrid').removeClass('displayIsBlock');
    $('.appSelectListItem').removeClass('appListItemSelected');
    $('.appSelectListItem').removeClass('appListItemSelectedMobile');

    $('.organisationContentGrid').eq(index).addClass('displayIsBlock');
    $('.appSelectListItem').eq(index).addClass('appListItemSelected');
    $('.appSelectListItem').eq(index).addClass('appListItemSelectedMobile');

    $('#organisationList').addClass('hideOrganisationListMobile');
    $('#selectListContent').addClass('showSelectListContent');
}

function showOrganisationListMobile()
{
    $('#organisationList').removeClass('hideOrganisationListMobile');
    $('#selectListContent').removeClass('showSelectListContent');
}


function toggleThemeRadioButtons()
{
    $('.aaRadioButtonSelectedText').removeClass('aaRadioButtonSelectedText');
    $('.aaRadioButtonSelected').removeClass('aaRadioButtonSelected');
    $('.aaRadioButtonSelectedHideInner').removeClass('aaRadioButtonSelectedHideInner');

    if(appAutoTheme)
    {
        $('#radioButtonAuto .twoColumnRowCol1').addClass('aaRadioButtonSelectedText');
        $('#radioButtonAuto .aaRadioButtonCircle').addClass('aaRadioButtonSelected');
        $('#radioButtonAuto .aaRadioButtonInner').addClass('aaRadioButtonSelectedHideInner');
    }
    else
    {
        if(appTheme == Theme.light)
        {
            $('#radioButtonLight .twoColumnRowCol1').addClass('aaRadioButtonSelectedText');
            $('#radioButtonLight .aaRadioButtonCircle').addClass('aaRadioButtonSelected');
            $('#radioButtonLight .aaRadioButtonInner').addClass('aaRadioButtonSelectedHideInner');
        }
        else if(appTheme == Theme.dark)
        {
            $('#radioButtonDark .twoColumnRowCol1').addClass('aaRadioButtonSelectedText');
            $('#radioButtonDark .aaRadioButtonCircle').addClass('aaRadioButtonSelected');
            $('#radioButtonDark .aaRadioButtonInner').addClass('aaRadioButtonSelectedHideInner');
        }
    }   
}

function setTheme(theme)
{
    if(theme == Theme.light)
    {
        var infoContainers = $('.infoContainerDark');
        infoContainers.removeClass('infoContainerDark');
        infoContainers.addClass('infoContainerLight');

        var allText = $('.textDark');
        allText.removeClass('textDark');
        allText.addClass('textLight');

        var appBackground = $('.appBackgroundDark');
        appBackground.removeClass('appBackgroundDark');
        appBackground.addClass('appBackgroundLight');

        var rowColumns = $('.twoColumnRowDark')
        rowColumns.removeClass('twoColumnRowDark');
        rowColumns.addClass('twoColumnRowLight');

        var menuBarContainer = $('.menuBarContainerDark');
        menuBarContainer.removeClass('menuBarContainerDark');
        menuBarContainer.addClass('menuBarContainerLight');

        var allButtons = $('.aaButtonDark');
        allButtons.removeClass('aaButtonDark');
        allButtons.addClass('aaButtonLight');

        $("img[src='icons/closeDark.svg']").attr('src', 'icons/closeLight.svg');
        $("img[src='icons/fullscreenDark.svg']").attr('src', 'icons/fullscreenLight.svg');
        $("img[src='icons/globeDark.svg']").attr('src', 'icons/globeLight.svg');
        $("img[src='icons/githubDark.svg']").attr('src', 'icons/githubLight.svg');

        var menuItemValues = $('.menuItemValueDark');
        menuItemValues.removeClass('menuItemValueDark');
        menuItemValues.addClass('menuItemValueLight');

        var organisationLocationText = $('.organisationLocationTextDark');
        organisationLocationText.removeClass('organisationLocationTextDark');
        organisationLocationText.addClass('organisationLocationTextLight');
    }
    else if(theme == Theme.dark)
    {
        var infoContainers = $('.infoContainerLight');
        infoContainers.removeClass('infoContainerLight');
        infoContainers.addClass('infoContainerDark');

        var allText = $('.textLight');
        allText.removeClass('textLight');
        allText.addClass('textDark');

        var appBackground = $('.appBackgroundLight');
        appBackground.removeClass('appBackgroundLight');
        appBackground.addClass('appBackgroundDark');

        var rowColumns = $('.twoColumnRowLight')
        rowColumns.removeClass('twoColumnRowLight');
        rowColumns.addClass('twoColumnRowDark');

        var menuBarContainer = $('.menuBarContainerLight');
        menuBarContainer.removeClass('menuBarContainerLight');
        menuBarContainer.addClass('menuBarContainerDark');

        var allButtons = $('.aaButtonLight');
        allButtons.removeClass('aaButtonLight');
        allButtons.addClass('aaButtonDark');

        $("img[src='icons/closeLight.svg']").attr('src', 'icons/closeDark.svg');
        $("img[src='icons/fullscreenLight.svg']").attr('src', 'icons/fullscreenDark.svg');
        $("img[src='icons/globeLight.svg']").attr('src', 'icons/globeDark.svg');
        $("img[src='icons/githubLight.svg']").attr('src', 'icons/githubDark.svg');

        var menuItemValues = $('.menuItemValueLight');
        menuItemValues.removeClass('menuItemValueLight');
        menuItemValues.addClass('menuItemValueDark');

        var organisationLocationText = $('.organisationLocationTextLight');
        organisationLocationText.removeClass('organisationLocationTextLight');
        organisationLocationText.addClass('organisationLocationTextDark');
    }

    appAutoTheme = false;
    localStorage["aa.autoTheme"] = false;
    appTheme = theme;
    localStorage["aa.theme"] = theme;
}

var setAutoTheme = function()
{
    var systemInLightMode = window.matchMedia('(prefers-color-scheme: light)');

    if(systemInLightMode.matches)
    {
        setTheme(Theme.light);
    }
    else
    {
        setTheme(Theme.dark);
    }

    appAutoTheme = true;
    localStorage["aa.autoTheme"] = true;
}

// Initialising website theme to either light or dark
var initialiseTheme = function()
{
    if(localStorage["aa.theme"] !== undefined)
    {
        appTheme = parseInt(localStorage["aa.theme"]);
    }
    if(localStorage["aa.autoTheme"] !== undefined)
    {
        appAutoTheme = localStorage["aa.autoTheme"] === "true";
    }

    if(appAutoTheme)
    {
        setAutoTheme();
        toggleThemeRadioButtons();
    }
    else
    {
        setTheme(appTheme);
        toggleThemeRadioButtons();
    }
}
$(document).ready(function(){
    initialiseTheme();
});

window.matchMedia('(prefers-color-scheme: light)').addEventListener('change', (event) => {
            if(appAutoTheme)
            {
                setAutoTheme();
            }
        });