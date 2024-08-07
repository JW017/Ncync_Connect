
const parallax_el = document.querySelectorAll(".parallax-b");
const main = document.querySelector("main");
let xValue = 0, yValue = 0, rotateDegree = 0;
const ssv = document.querySelector('.ssv')
const psv = document.querySelector('.psv')

/* GSAP Animation */

let timeline = gsap.timeline();

timeline.to(
        ".ssv",
        {
            y: -60,
            duration: 2.5,
            opacity: 1,
            ease: "power3.out",
        },
        "0.5"
    );



timeline
    .from(
        ".text-b h1",
        {
            y: window.innerHeight - document.querySelector(".text-b h1").getBoundingClientRect().top + 200,
            duration: 1,
            opacity: 0,
        },
        "1"
    )
    .from(
        ".text-b h2",
        {
            y: -150,
            opacity: 0,
            duration: 1,
        },
        "1"
    )
    .from(
        ".hide-b",
        {
            opacity: 0,
            duration: 1.5,
        },
        "1.5"
);

//window.addEventListener("mousemove", (e) => {

//    if (window.innerWidth >= 725) {
//        main.style.maxHeight = `${window.innerWidth * 0.6}px`;
//    } else {
//        main.style.maxHeight = `${window.innerWidth * 1.6}px`;
//    }
//})

document.addEventListener("scroll", function () {

    let value = window.scrollY
    console.log(value)

    if (window.innerWidth >= 1024) {
        ssv.style.left = 360 + value * 1 + 'px'
        psv.style.right = 0 + value * 1 + 'px'
    }
    else if (window.innerWidth > 821 && window.innerWidth < 1024) {
            ssv.style.left = 280 + value * 1 + 'px'
            psv.style.right = -100 + value * 1 + 'px'
    }
    else if (window.innerWidth > 480 && window.innerWidth < 821) {
        ssv.style.left = 0 + value * 1 + 'px'
        psv.style.right = -1350 + value * 1 + 'px'
    }
    else if (window.innerWidth <= 480) {
        ssv.style.left = 0 + value * 1 + 'px'
        psv.style.right = -850 + value * 1 + 'px'
    }
})


/* ScrollReveal */

ScrollReveal({
    reset: true,
    distance: '80px',
    duration: 2000,
    delay: 400
});

ScrollReveal().reveal('.main-title-01', { delay: 500, origin: 'left' });
ScrollReveal().reveal('.sec-01 .video-01', { delay: 600, origin: 'bottom' });
ScrollReveal().reveal('.side-text-01', { delay: 700, origin: 'right' });
ScrollReveal().reveal('.section-title-01', { delay: 400, origin: 'top' });
ScrollReveal().reveal('.sec-03 .image-01', { delay: 500, origin: 'top' });
ScrollReveal().reveal('.media-info-01 li', { delay: 500, origin: 'left', interval: 200 });