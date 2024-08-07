function filterFunction(input, pdiv, p) {
    const Input = document.getElementById(input);
    const Filter = Input.value.toUpperCase();
    const Div = document.getElementById(pdiv);
    const Tag = Div.getElementsByTagName(p);
    for (let i = 0; i < Tag.length; i++) {
        txtValue = Tag[i].textContent || Tag[i].innerText;
        if (txtValue.toUpperCase().indexOf(Filter) > -1) {
            Tag[i].style.display = "";
        } else {
            Tag[i].style.display = "none";
        }
    }

    document.addEventListener('click', function (event) {
        if (!Input.contains(event.target)) {
            Input.value = '';
            for (let i = 0; i < Tag.length; i++) {
                Tag[i].style.display = "block";
            }
        }
    });
}


function openDropFunction() {

    document.getElementById("filter-myDropdown").classList.toggle("filter-show");
}

function dropFunction() {
    const input = document.getElementById("filter-myInput");
    const filter = input.value.toUpperCase();
    const div = document.getElementById("filter-myDropdown");
    const a = div.getElementsByTagName("a");
    for (let i = 0; i < a.length; i++) {
        txtValue = a[i].textContent || a[i].innerText;
        if (txtValue.toUpperCase().indexOf(filter) > -1) {
            a[i].style.display = "";
        } else {
            a[i].style.display = "none";
        }
    }

    /*filterFunction('filter-myInput', 'filter-myDropdown', 'a');*/

    const divA = document.getElementById("filter-myDropdown-a");
    const aA = divA.getElementsByTagName("h6");
    for (let i = 0; i < aA.length; i++) {
        txtValue = aA[i].textContent || aA[i].innerText;
        if (txtValue.toUpperCase().indexOf(filter) > -1) {
            aA[i].style.display = "";
        } else {
            aA[i].style.display = "none";
        }
    }

    document.addEventListener('click', function (event) {
        if (!input.contains(event.target)) {
            input.value = '';
            for (let i = 0; i < aA.length; i++) {
                aA[i].style.display = "block";
            }
        }
    });
}

window.removeBackdropClass = function () {
    let backdrop = document.querySelector('.modal-backdrop.fade.show');
    if (backdrop) {
        backdrop.classList = ('.modal-backdrop.fade');
    }
};
