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

    document.getElementById('menuBarMobilePopout').classList.toggle('showMenuBarMobilePopout', Boolean(showPopoutMenu));
    document.getElementById('menuBarMobilePopoutBackground').classList.toggle('opacityFull', Boolean(showPopoutMenu));
}

function openProjectFullscreen(projectIndex)
{
    document.querySelectorAll('.projectWindow')[projectIndex].classList.add('opacityFull');
    document.getElementById('projectWindowGreyedOutBackground').classList.add('opacityFull');
}
function closeProjectFullscreen()
{
    document.querySelectorAll('.projectWindow').forEach((element) => {
        element.classList.remove('opacityFull');
    });
    document.getElementById('projectWindowGreyedOutBackground').classList.remove('opacityFull');
}

// Making the first organisation info visible / selected on load for desktop
document.addEventListener('DOMContentLoaded', () => {
    document.querySelectorAll('.organisationContentGrid')[0]?.classList.add('displayIsBlock');
    document.querySelectorAll('.appSelectListItem')[0]?.classList.add('appListItemSelected');
})

function selectOrganisation(index)
{
    const organisationContentGrids = document.querySelectorAll('.organisationContentGrid');
    const appSelectListItems = document.querySelectorAll('.appSelectListItem');

    organisationContentGrids.forEach(element => { element.classList.remove('displayIsBlock'); });
    appSelectListItems.forEach(element => { element.classList.remove('appListItemSelected', 'appListItemSelectedMobile'); });

    organisationContentGrids[index].classList.add('displayIsBlock');
    appSelectListItems[index].classList.add('appListItemSelected', 'appListItemSelectedMobile');

    document.getElementById('organisationList').classList.add('hideOrganisationListMobile');
    document.getElementById('selectListContent').classList.add('showSelectListContent');
}

function showOrganisationListMobile()
{
    document.getElementById('organisationList').classList.remove('hideOrganisationListMobile');
    document.getElementById('selectListContent').classList.remove('showSelectListContent');
}


function toggleThemeRadioButtons()
{
    document.querySelectorAll('.aaRadioButtonSelectedText').forEach(element => { element.classList.remove('aaRadioButtonSelectedText'); })
    document.querySelectorAll('.aaRadioButtonSelected').forEach(element => { element.classList.remove('aaRadioButtonSelected'); })
    document.querySelectorAll('.aaRadioButtonSelectedHideInner').forEach(element => { element.classList.remove('aaRadioButtonSelectedHideInner'); })

    if(appAutoTheme)
    {
        document.querySelectorAll('#radioButtonAuto .twoColumnRowCol1').forEach(element => { element.classList.add('aaRadioButtonSelectedText'); });
        document.querySelectorAll('#radioButtonAuto .aaRadioButtonCircle').forEach(element => { element.classList.add('aaRadioButtonSelected'); });
        document.querySelectorAll('#radioButtonAuto .aaRadioButtonInner').forEach(element => { element.classList.add('aaRadioButtonSelectedHideInner'); });
    }
    else
    {
        if(appTheme == Theme.light)
        {
            document.querySelectorAll('#radioButtonLight .twoColumnRowCol1').forEach(element => { element.classList.add('aaRadioButtonSelectedText'); });
            document.querySelectorAll('#radioButtonLight .aaRadioButtonCircle').forEach(element => { element.classList.add('aaRadioButtonSelected'); });
            document.querySelectorAll('#radioButtonLight .aaRadioButtonInner').forEach(element => { element.classList.add('aaRadioButtonSelectedHideInner'); });
        }
        else if(appTheme == Theme.dark)
        {
            document.querySelectorAll('#radioButtonDark .twoColumnRowCol1').forEach(element => { element.classList.add('aaRadioButtonSelectedText'); });
            document.querySelectorAll('#radioButtonDark .aaRadioButtonCircle').forEach(element => { element.classList.add('aaRadioButtonSelected'); });
            document.querySelectorAll('#radioButtonDark .aaRadioButtonInner').forEach(element => { element.classList.add('aaRadioButtonSelectedHideInner'); });
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
        document.querySelectorAll("img[src='icons/backLight.svg']").forEach(element => {
            element.setAttribute("src", "icons/backDark.svg");
        });
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
document.addEventListener('DOMContentLoaded', () => {
    initialiseTheme();
})

window.matchMedia('(prefers-color-scheme: light)').addEventListener('change', (event) => {
            if(appAutoTheme)
            {
                setAutoTheme();
            }
        });