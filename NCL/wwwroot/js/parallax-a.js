const parallax_el = document.querySelectorAll(".parallax-a");
const main = document.querySelector("main");
let xValue = 0, yValue = 0, rotateDegree = 0;

function update(cursorPosition) {
    parallax_el.forEach(el => {
        let speedx = el.dataset.speedx;
        let speedy = el.dataset.speedy;
        let speedz = el.dataset.speedz;
        let speedrotation = el.dataset.rotation;

        let isInLeft = parseFloat(getComputedStyle(el).left) < window.innerHeight / 2 ? 1 : -1;
        isInLeft * 0.1;
        let zValue = (cursorPosition - parseFloat(getComputedStyle(el).left)) * isInLeft;

        el.style.transform =
            `translateX(calc(-50% + ${xValue * speedx}px)) 
            translateY(calc(-50% + ${yValue * speedy}px)) 
            perspective(2300px)
            translateZ(${zValue * speedz}px)
            rotateY(${rotateDegree * speedrotation}deg)`;
    })
}

update(0);

window.addEventListener("mousemove", (e) => {
    if (timeline.isActive()) return;

    xValue = e.clientX - window.innerWidth / 2;
    yValue = e.clientY - window.innerHeight / 2;
    rotateDegree = (xValue / (window.innerWidth / 2)) * 20;

    update(e.clientX);

    if (window.innerWidth >= 725) {
        main.style.maxHeight = `${window.innerWidth * 0.6}px`;
    } else {
        main.style.maxHeight = `${window.innerWidth * 1.6}px`;
    }
})



/* GSAP Animation */

let timeline = gsap.timeline();

Array.from(parallax_el).filter((el) => !el.classList.contains("text-a")).forEach((el) => {
    timeline.from(
        el,
        {
            y: `${el.offsetHeight / 2 + +el.dataset.distance}px`,
            duration: 2.5,
            ease: "power3.out",
        },
        "0.5"
    );
});




timeline
    .from(
        ".text-a h1",
        {
            y: window.innerHeight - document.querySelector(".text-a h1").getBoundingClientRect().top + 200,
            duration: 2,
        },
        "1.5"
    )
    .from(
        ".text-a h2",
        {
            y: -150,
            opacity: 0,
            duration: 1.5,
        },
        "2"
    )
    .from(
        ".hide-a",
        {
            opacity: 0,
            duration: 1.5,
        },
        "2"
    );