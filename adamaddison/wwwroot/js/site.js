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
        document.querySelectorAll("img[src='icons/closeDark.svg']").forEach(element => {
            element.setAttribute("src", "icons/closeLight.svg");
        });
        document.querySelectorAll("img[src='icons/fullscreenDark.svg']").forEach(element => {
            element.setAttribute("src", "icons/fullscreenLight.svg");
        });
        document.querySelectorAll("img[src='icons/globeDark.svg']").forEach(element => {
            element.setAttribute("src", "icons/globeLight.svg");
        });
        document.querySelectorAll("img[src='icons/githubDark.svg']").forEach(element => {
            element.setAttribute("src", "icons/githubLight.svg");
        });
        document.querySelectorAll("img[src='icons/backDark.svg']").forEach(element => {
            element.setAttribute("src", "icons/backLight.svg");
        });

        var allHeaders = $('.headerDark');
        allHeaders.removeClass('headerDark');
        allHeaders.addClass('headerLight');

        var projectContentWrappers = $('.projectContentWrapperDark');
        projectContentWrappers.removeClass('projectContentWrapperDark');
        projectContentWrappers.addClass('projectContentWrapperLight');

        var workEducationHeader = $('.appSelectListHeaderDark');
        workEducationHeader.removeClass('appSelectListHeaderDark');
        workEducationHeader.addClass('appSelectListHeaderLight');

        var workEducationItem = $('.appSelectListItemDark');
        workEducationItem.removeClass('appSelectListItemDark');
        workEducationItem.addClass('appSelectListItemLight');

        var workEducationList = $('.appSelectListDark');
        workEducationList.removeClass('appSelectListDark');
        workEducationList.addClass('appSelectListLight');

        var allTables = $('.schoolGradeTableDark');
        allTables.removeClass('schoolGradeTableDark');
        allTables.addClass('schoolGradeTableLight');

        var alternatingRows = $('.alternatingRowDark');
        alternatingRows.removeClass('alternatingRowDark');
        alternatingRows.addClass('alternatingRowLight');

        var projectWindows = $('.projectWindowDark');
        projectWindows.removeClass('projectWindowDark');
        projectWindows.addClass('projectWindowLight');

        var radioButtonOuter = $('.aaRadioButtonOuterDark');
        radioButtonOuter.removeClass('aaRadioButtonOuterDark');
        radioButtonOuter.addClass('aaRadioButtonOuterLight');

        var radioButtonInner = $('.aaRadioButtonInnerDark');
        radioButtonInner.removeClass('aaRadioButtonInnerDark');
        radioButtonInner.addClass('aaRadioButtonInnerLight');

        var radioButtonCircle = $('.aaRadioButtonCircleDark');
        radioButtonCircle.removeClass('aaRadioButtonCircleDark');
        radioButtonCircle.addClass('aaRadioButtonCircleLight');

        var menuLines = $('.menuIconLineDark');
        menuLines.removeClass('menuIconLineDark');
        menuLines.addClass('menuIconLineLight');

        var mobileMenu = $('.menuBarContainerMobileDark');
        mobileMenu.removeClass('menuBarContainerMobileDark');
        mobileMenu.addClass('menuBarContainerMobileLight');

        var mobileMenuItem = $('.menuItemMobileDark');
        mobileMenuItem.removeClass('menuItemMobileDark');
        mobileMenuItem.addClass('menuItemMobileLight');

        var tableFooter = $('.gradeTableFooterDark');
        tableFooter.removeClass('gradeTableFooterDark');
        tableFooter.addClass('gradeTableFooterLight');
    }
    else if(theme == Theme.dark)
    {
        document.querySelectorAll("img[src='icons/closeLight.svg']").forEach(element => {
            element.setAttribute("src", "icons/closeDark.svg");
        });
        document.querySelectorAll("img[src='icons/fullscreenLight.svg']").forEach(element => {
            element.setAttribute("src", "icons/fullscreenDark.svg");
        });
        document.querySelectorAll("img[src='icons/globeLight.svg']").forEach(element => {
            element.setAttribute("src", "icons/globeDark.svg");
        });
        document.querySelectorAll("img[src='icons/githubLight.svg']").forEach(element => {
            element.setAttribute("src", "icons/githubDark.svg");
        });
        $("img[src='icons/backLight.svg']").attr('src', 'icons/backDark.svg');
        document.querySelectorAll("img[src='icons/backLight.svg']").forEach(element => {
            element.setAttribute("src", "icons/backDark.svg");
        });

        var allHeaders = $('.headerLight');
        allHeaders.removeClass('headerLight');
        allHeaders.addClass('headerDark');

        var projectContentWrappers = $('.projectContentWrapperLight');
        projectContentWrappers.removeClass('projectContentWrapperLight');
        projectContentWrappers.addClass('projectContentWrapperDark');

        var workEducationHeader = $('.appSelectListHeaderLight');
        workEducationHeader.removeClass('appSelectListHeaderLight');
        workEducationHeader.addClass('appSelectListHeaderDark');

        var workEducationItem = $('.appSelectListItemLight');
        workEducationItem.removeClass('appSelectListItemLight');
        workEducationItem.addClass('appSelectListItemDark');

        var workEducationList = $('.appSelectListLight');
        workEducationList.removeClass('appSelectListLight');
        workEducationList.addClass('appSelectListDark');

        var allTables = $('.schoolGradeTableLight');
        allTables.removeClass('schoolGradeTableLight');
        allTables.addClass('schoolGradeTableDark');

        var alternatingRows = $('.alternatingRowLight');
        alternatingRows.removeClass('alternatingRowLight');
        alternatingRows.addClass('alternatingRowDark');

        var projectWindows = $('.projectWindowLight');
        projectWindows.removeClass('projectWindowLight');
        projectWindows.addClass('projectWindowDark');

        var radioButtonOuter = $('.aaRadioButtonOuterLight');
        radioButtonOuter.removeClass('aaRadioButtonOuterLight');
        radioButtonOuter.addClass('aaRadioButtonOuterDark');

        var radioButtonInner = $('.aaRadioButtonInnerLight');
        radioButtonInner.removeClass('aaRadioButtonInnerLight');
        radioButtonInner.addClass('aaRadioButtonInnerDark');

        var radioButtonCircle = $('.aaRadioButtonCircleLight');
        radioButtonCircle.removeClass('aaRadioButtonCircleLight');
        radioButtonCircle.addClass('aaRadioButtonCircleDark');

        var menuLines = $('.menuIconLineLight');
        menuLines.removeClass('menuIconLineLight');
        menuLines.addClass('menuIconLineDark');

        var mobileMenu = $('.menuBarContainerMobileLight');
        mobileMenu.removeClass('menuBarContainerMobileLight');
        mobileMenu.addClass('menuBarContainerMobileDark');

        var mobileMenuItem = $('.menuItemMobileLight');
        mobileMenuItem.removeClass('menuItemMobileLight');
        mobileMenuItem.addClass('menuItemMobileDark');

        var tableFooter = $('.gradeTableFooterLight');
        tableFooter.removeClass('gradeTableFooterLight');
        tableFooter.addClass('gradeTableFooterDark');
    }

    appAutoTheme = false;
    localStorage["aa.autoTheme"] = false;
    appTheme = theme;
    localStorage["aa.theme"] = theme;
    document.documentElement.setAttribute("data-theme-aa", theme);
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