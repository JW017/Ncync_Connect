
    // SIDEBAR TOGGLE
    var sidebarOpen = false;
    var sidebar = document.getElementById("sidebar");

    function openSidebar() {
        if (!sidebarOpen) {
        sidebar.classList.add("sidebar-responsive");
    sidebarOpen = true;
        }
    else {
        sidebar.classList.remove("sidebar-responsive");
    sidebarOpen = false;
        }
    }

    function closeSidebar() {
        if (sidebarOpen) {
        sidebar.classList.remove("sidebar-responsive");
    sidebarOpen = false;
        }
    }

// SIDEBAR TOGGLE
    var subMenuOpen = false;
    var subMenu = document.getElementById("subMenu");

    function toggleMenu() {
        if (!subMenuOpen) {
        subMenu.classList.add("open-menu");
    subMenuOpen = true;
        }
    else {
        subMenu.classList.remove("open-menu");
    subMenuOpen = false;
        }
}

// LOGOUT NAVIGATION
    function BeginLogOut() {
        window.location.href = "/MicrosoftIdentity/Account/SignOut";
}



    // // Set a boolean flag to track whether the page has been reloaded
    // let hasReloaded = false;

    // // Function to reload the page only once
    // function LoadOnce() {

    //     // Check if the page has not been reloaded yet
    //     if (!hasReloaded) {
    //         // Reload the page
    //         window.location.reload();
    //         // Set the flag to true to indicate that the page has been reloaded
    //         hasReloaded = true;
    //     }
    // }



