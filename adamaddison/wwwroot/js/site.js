let showPopoutMenu = false;

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