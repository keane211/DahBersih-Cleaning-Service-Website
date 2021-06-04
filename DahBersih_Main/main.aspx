<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="Dahbersih.sln.main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta3/dist/css/bootstrap.min.css" rel="stylesheet"/>
    <link href="Style/keane.css" rel="stylesheet" />
    <link rel="stylesheet" href="../lib/font-awesome/css/all.css" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta3/dist/js/bootstrap.bundle.min.js"></script>
    <style>
        @import url('https://fonts.googleapis.com/css2?family=Lobster&display=swap');
        @import url('https://fonts.googleapis.com/css2?family=Lato:ital,wght@0,300;0,400;1,400&display=swap');
    </style>
    <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?sensor=false"></script>
    <title>Dahbersih | Welcome Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <nav class="dahbersih-navbar d-inline-flex w-100 justify-content-between">
        <a href="main.aspx"><img src="images/Logo-transparent.png" alt="Dahbersih Logo" class="dahbersih-logo" width="80"/></a>
        <ul class="nav justify-content-end">
            <li class="nav-item d-flex">
                <a class="nav-link active m-auto" href="#about">About Us</a>
            </li>
            <li class="nav-item d-flex">
                <a class="nav-link m-auto" href="#service">Services</a>
            </li>
            <li class="nav-item d-flex">
                <a class="nav-link m-auto" href="#contactus">Contact Us</a>
            </li>
            <asp:PlaceHolder ID="Navigation" runat="server"></asp:PlaceHolder>
        </ul>
    </nav>
    <div class="dahbersih-welcome-section">
        <div class="overlay"></div>
        <div class="dahbersih-welcome-section-content">
            <h1 class="mb-4"><b>DahBersih – <br /> let us deal with the mess!</b></h1>
            <asp:PlaceHolder ID="LandingSession" runat="server"></asp:PlaceHolder>
        </div>
        </div>
    
    <div class="dahbersih-why-us-section text-center">
        <h1>Why choose us?</h1>
        <hr class="mb-3"/>
        <div class="d-inline-flex dahbersih-why-us-section-content justify-content-around mt-5">
            <div class="why-us-factor">
                <i class="fa fa-award mb-3"></i>
                <h5>Quality Work</h5>
            </div>
            <div class="why-us-factor">
                <i class="fas fa-coins mb-3"></i>
                <h5>Reasonable Pricing</h5>
            </div>
            <div class="why-us-factor">
                <i class="far fa-clock mb-3"></i>
                <h5>Flexible Appointments</h5>
            </div>
            <div class="why-us-factor">
                <i class="fas fa-users mb-3"></i>
                <h5>Uniformed, <br /> Professionally Trained Staff</h5>
            </div>
        </div>
    </div>
    <div class="about-us-section text-center" id="about">
        <h1 class="mb-3">About Us</h1>
        <p>With the current Covid-19 situation around the world, cleanliness and disinfection is becoming one of the main things we should be concerned about. New norms dictate new rules. </p><br />
        <p>Dahbersih Cleaning Agency was established in 2018 to satisfy our customers with deep cleaning solutions using the latest technology and techniques. Dahbersih offer residential, office and post renovation cleaning. </p><br />
        <p>Our team offers both complex cleaning of the entire property and partially selected services.</p>
        <p>Your satisfaction is our priority!</p>
    </div>
    <div class="reviews-section text-center">
        <h1 class="mb-3">Reviews</h1>
        <div id="slider" class="slider">
		<div class="slider-content">
			<div class="slider-content-wrapper">
                <asp:PlaceHolder ID="FeedbackSection" runat="server"></asp:PlaceHolder>
			</div>
		</div>
	</div>
        </div>
    <hr />
    <div class="our-services-section text-center" id="service">
        <h1>Our Services</h1>
        <asp:PlaceHolder ID="ServicesSection" runat="server"></asp:PlaceHolder>
    </div>
    <div class="guestbook-section">
        <h1>Ask us a question</h1>
            <div class="guestbook-section-content mt-3 d-inline-flex">
                <div class="col-3">
                    <h5>Email</h5>
                </div>
                <div class="col-9">
                    <asp:TextBox ID="Email" class="w-100" runat="server" TextMode="SingleLine"></asp:TextBox><br />
                    <asp:RequiredFieldValidator ID="EmailRequiredFieldValidator" ControlToValidate="Email" runat="server" ErrorMessage="Please Enter Your Email Address" ForeColor="Red"></asp:RequiredFieldValidator><br />
                    <asp:RegularExpressionValidator ID="EmailRegularExpressionValidator" ControlToValidate="Email" runat="server" ErrorMessage="Invalid Email Address" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </div>
            </div>
            <div class="guestbook-section-content mt-2 d-inline-flex">
                <div class="col-3">
                    <h5>Comment</h5>
                </div>
                <div class="col-9">
                    <asp:TextBox ID="Comment" class="w-100" style ="resize:none" cols="20" rows="5" runat="server" TextMode="MultiLine"></asp:TextBox><br />
                    <asp:RequiredFieldValidator ID="CommentRequiredFieldValidator" ControlToValidate="Comment" runat="server" ErrorMessage="Please Write Your Comment" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="col-12">
                <asp:Button ID="FeedbackSubmitButton" class="btn btn-primary dahbersih-submit-btn mt-4" runat="server" Text="Submit" OnClick="FeedbackSubmitButton_Click" />
            </div>
    </div>
    <footer>
        <div class="col-6">
            <h3 class="mb-4" id="contactus">Contact Us</h3>
            <div class="d-inline-flex w-100">
                <div class="col-2">
                    <p class="mb-0"><b>Email:</b></p>
                </div>
                <div class="col-10">
                    dahbersih@gmail.com
                </div>
            </div><br />
            <div class="d-inline-flex w-100">
                <div class="col-2">
                    <p class="mb-0"><b>Telephone:</b></p>
                </div>
                <div class="col-10">
                    +601 8965 6345
                </div>
            </div>
            <div class="d-inline-flex w-100 mt-3">
                <div class="col-2">
                    <p><b>Address:</b></p>
                </div>
                <div class="col-10">
                    Jalan Teknologi 5, Taman Teknologi Malaysia, 57000 Kuala Lumpur, Wilayah Persekutuan Kuala Lumpur
                </div>
                <br/>
           </div>
            <div class="col-12 mt-4">
                    &copy Copyright 2021 by DahBersih. All Rights Reserved. 
                </div>
            </div>
   
        <div class="col-6 d-flex justify-content-end" style="color: #003f69">
            <div id="map_canvas" style="width: 500px; height: 175px"></div>
        </div>
    </footer>
    </form>
</body>

    <script>
        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(success);
        } else {
            alert("Geo Location is not supported on your current browser!");
        }
        function success(position) {
            var lat = 3.0561382053403703;
            var long = 101.70042632695154;
            var city = position.coords.locality;
            var myLatlng = new google.maps.LatLng(3.0561382053403703, 101.70042632695154);
            var myOptions = {
                center: myLatlng,
                zoom: 12,
                mapTypeId: google.maps.MapTypeId.ROADMAP
            };
            var map = new google.maps.Map(document.getElementById("map_canvas"), myOptions);
            var marker = new google.maps.Marker({
                position: myLatlng,
                title: "My title"
            });
            marker.setMap(map);
            var infowindow = new google.maps.InfoWindow({ content: "<b>APU</b><br/> Address: Jalan Teknologi 5, Taman Teknologi Malaysia, 57000 Kuala Lumpur, Wilayah Persekutuan Kuala Lumpur" });
            infowindow.open(map, marker);
        }
        const slider = (function () {


            const slider = document.getElementById("slider");
            console.log(slider);
            const sliderContent = document.querySelector(".slider-content");
            console.log(sliderContent);
            const sliderWrapper = document.querySelector(".slider-content-wrapper");
            const elements = document.querySelectorAll(".slider-content__item");
            const sliderContentControls = createHTMLElement("div", "slider-content__controls");
            let dotsWrapper = null;
            let leftArrow = null;
            let rightArrow = null;
            let intervalId = null;


            const itemsInfo = {
                offset: 0,
                position: {
                    current: 0,
                    min: 0,
                    max: elements.length - 1
                },
                intervalSpeed: 2000,

                update: function (value) {
                    this.position.current = value;
                    this.offset = -value;
                },
                reset: function () {
                    this.position.current = 0;
                    this.offset = 0;
                }
            };

            const controlsInfo = {
                buttonsEnabled: false,
                dotsEnabled: false,
                prevButtonDisabled: true,
                nextButtonDisabled: false
            };


            function init(props) {

                let { intervalSpeed, position, offset } = itemsInfo;


                if (slider && sliderContent && sliderWrapper && elements) {

                    if (props && props.intervalSpeed) {
                        intervalSpeed = props.intervalSpeed;
                    }
                    if (props && props.currentItem) {
                        if (parseInt(props.currentItem) >= position.min && parseInt(props.currentItem) <= position.max) {
                            position.current = props.currentItem;
                            offset = - props.currentItem;
                        }
                    }
                    if (props && props.buttons) {
                        controlsInfo.buttonsEnabled = true;
                    }
                    if (props && props.dots) {
                        controlsInfo.dotsEnabled = true;
                    }

                    _updateControlsInfo();
                    _createControls(controlsInfo.dotsEnabled, controlsInfo.buttonsEnabled);
                    _render();
                } else {
                    console.log("Error");
                }
            }


            function _updateControlsInfo() {
                const { current, min, max } = itemsInfo.position;
                controlsInfo.prevButtonDisabled = current > min ? false : true;
                controlsInfo.nextButtonDisabled = current < max ? false : true;
            }


            function _createControls(dots = false, buttons = false) {


                sliderContent.append(sliderContentControls);


                createArrows();
                dots ? createDots() : null;


                function createArrows() {
                    const dValueLeftArrow = "M31.7 239l136-136c9.4-9.4 24.6-9.4 33.9 0l22.6 22.6c9.4 9.4 9.4 24.6 0 33.9L127.9 256l96.4 96.4c9.4 9.4 9.4 24.6 0 33.9L201.7 409c-9.4 9.4-24.6 9.4-33.9 0l-136-136c-9.5-9.4-9.5-24.6-.1-34z";
                    const dValueRightArrow = "M224.3 273l-136 136c-9.4 9.4-24.6 9.4-33.9 0l-22.6-22.6c-9.4-9.4-9.4-24.6 0-33.9l96.4-96.4-96.4-96.4c-9.4-9.4-9.4-24.6 0-33.9L54.3 103c9.4-9.4 24.6-9.4 33.9 0l136 136c9.5 9.4 9.5 24.6.1 34z";
                    const leftArrowSVG = createSVG(dValueLeftArrow);
                    const rightArrowSVG = createSVG(dValueRightArrow);

                    leftArrow = createHTMLElement("div", "prev-arrow");
                    leftArrow.append(leftArrowSVG);
                    leftArrow.addEventListener("click", () => updateItemsInfo(itemsInfo.position.current - 1))

                    rightArrow = createHTMLElement("div", "next-arrow");
                    rightArrow.append(rightArrowSVG);
                    rightArrow.addEventListener("click", () => updateItemsInfo(itemsInfo.position.current + 1))

                    sliderContentControls.append(leftArrow, rightArrow);


                    function createSVG(dValue, color = "currentColor") {
                        const svg = document.createElementNS("http://www.w3.org/2000/svg", "svg");
                        svg.setAttribute("viewBox", "0 0 256 512");
                        const path = document.createElementNS("http://www.w3.org/2000/svg", "path");
                        path.setAttribute("fill", color);
                        path.setAttribute("d", dValue);
                        svg.appendChild(path);
                        return svg;
                    }
                }


                function createDots() {
                    dotsWrapper = createHTMLElement("div", "dots");
                    for (let i = 0; i < itemsInfo.position.max + 1; i++) {
                        const dot = document.createElement("div");
                        dot.className = "dot";
                        dot.addEventListener("click", function () {
                            updateItemsInfo(i);
                        })
                        dotsWrapper.append(dot);
                    }
                    sliderContentControls.append(dotsWrapper);
                }
            }


            function setClass(options) {
                if (options) {
                    options.forEach(({ element, className, disabled }) => {
                        if (element) {
                            disabled ? element.classList.add(className) : element.classList.remove(className)
                        } else {
                            console.log("Error: function setClass(): element = ", element);
                        }
                    })
                }
            }


            function updateItemsInfo(value) {
                itemsInfo.update(value);
                _slideItem(true);
            }


            function _render() {
                const { prevButtonDisabled, nextButtonDisabled } = controlsInfo;
                let controlsArray = [
                    { element: leftArrow, className: "d-none", disabled: prevButtonDisabled },
                    { element: rightArrow, className: "d-none", disabled: nextButtonDisabled }
                ];
                if (controlsInfo.buttonsEnabled) {
                    controlsArray = [
                        ...controlsArray,
                        { element: prevButton, className: "disabled", disabled: prevButtonDisabled },
                        { element: nextButton, className: "disabled", disabled: nextButtonDisabled }
                    ];
                }


                setClass(controlsArray);


                sliderWrapper.style.transform = `translateX(${itemsInfo.offset * 100}%)`;


                if (controlsInfo.dotsEnabled) {
                    if (document.querySelector(".dot--active")) {
                        document.querySelector(".dot--active").classList.remove("dot--active");
                    }
                    dotsWrapper.children[itemsInfo.position.current].classList.add("dot--active");
                }
            }


            function _slideItem(autoMode = false) {
                if (autoMode && intervalId) {
                    clearInterval(intervalId);
                }
                _updateControlsInfo();
                _render();
            }


            function createHTMLElement(tagName = "div", className, innerHTML) {
                const element = document.createElement(tagName);
                className ? element.className = className : null;
                innerHTML ? element.innerHTML = innerHTML : null;
                return element;
            }
            return { init };
        }())

        slider.init({

            currentItem: 0,
            buttons: false,
            dots: true
        });
    </script>
</html>
