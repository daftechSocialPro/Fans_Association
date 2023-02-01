import React, { useEffect, useState } from "react";
import { BsFacebook, BsTwitter, BsYoutube } from "react-icons/bs";
import { GrMail, GrInstagram, GrDocumentImage } from "react-icons/gr";
import axios from "axios";
import { urlMahber, assetUrl } from "../endpoints";
import { useLocation, Link } from "react-router-dom";
function NavBar() {
  const [club, setClub] = useState([]);
  const location = useLocation();

  useEffect(() => {
    axios.get(urlMahber).then((res) => setClub(res.data));
  }, []);
  const getImage = (item) => {
    const imagePath = `${assetUrl}/${item}`;
    //"image path", imagePath);

    return imagePath;
  };

  return (
    <header className="masthead" >
      <nav
        className="clubNavigation"
        data-script="pl_global-header"
        role="menubar"
      >
        <div className="clubSitesHeading">
          <h4 style={{ fontSize: "16px" }}>
            የደጋፊ ማህበር ድረ ገጽ<div className="icon"></div>
          </h4>
        </div>
        <ul className="clubList" role="menu">
          {club.map((item) => (
            <li key={item.id} >
              <a target="_blank" href={item.websiteAdress}>
                <div
                  className="badge badge--small badge-image-container"
                  data-widget="club-badge-image"
                  data-size="25"
                >
                  <img
                    className="badge-image badge-image--25 js-badge-image"
                    src={getImage(item.logo)}
                  />
                </div>
                <div
                  className="badge badge--large badge-image-container"
                  data-widget="club-badge-image"
                  data-size="50"
                >
                  <img
                    className="badge-image badge-image--50 js-badge-image"
                    src={getImage(item.logo)}
                  />
                  <span className="visuallyHidden">{item.name}</span>
                </div>
                <span className="name">{item.name}</span>
              </a>
            </li>
          ))}
        </ul>
      </nav>

      <div className="fixedContainer">
        <a
          href="/"
          className="u-hide-tab logoContainer"
          aria-label="Premier League Home Page on logo link"
        >
          <div className="logo">
            <img src="/assets/logo.png" />
          </div>

          <div className="logoBackground"></div>
          <span className="mobile">
            <img
              src="resources/prod/v6.103.2-4532/i/elements/premier-league-logo-header-mob.svg"
              alt="Premier League Logo"
            />
          </span>
        </a>
        <div className="navContainer" data-script="pl_global-header">
          <section id="mainNav" className="navBar" role="menubar">
            <div
              className="menuBtn"
              role="button"
              id="hamburgerToggle"
              aria-expanded="false"
            >
              <div className="menuBtnContainer">
                <div></div>
                <div></div>
                <div></div>
              </div>
            </div>

            <nav className="mainNav">
              <ul className="pageLinks" role="menu">
                <li
                  className=" premierleague 
    "
                  aria-haspopup="true"
                  role="menuitem"
                >
                  <div role="button" className="navLink active  ">
                    <span className="navText" style={{ fontSize: "22px" }}>
                      የኢትዮጵያ ፕሪሚየር ሊግ ደጋፊዎች ማህበራት ጥምረት
                    </span>
                  </div>
                </li>
              </ul>
            </nav>

           

            <a
              href="https://users.premierleague.com/?redirect_uri=https://www.premierleague.com/&amp;app=pl-web"
              className="navLink navOption navOption--no-border fantasySignIn"
              role="button"
            >
              <span className="fantasySignInLabel"></span>
            </a>

            <a
              href="NoRoomForRacism.html"
              className=" noroomforracism hide-ms navLink navOption  "
              role="button"
            >
              <div className="icn user-w show-m"></div>
              <span className="featuredLinkTitle">
                {" "}
                <GrInstagram />{" "}
              </span>
            </a>
            <a
              href="NoRoomForRacism.html"
              className=" noroomforracism hide-ms navLink navOption  "
              role="button"
            >
              <div className="icn user-w show-m"></div>
              <span className="featuredLinkTitle">
                {" "}
                <GrMail />{" "}
              </span>
            </a>
            <a
              href="NoRoomForRacism.html"
              className=" noroomforracism hide-ms navLink navOption  "
              role="button"
            >
              <div className="icn user-w show-m"></div>
              <span className="featuredLinkTitle">
                {" "}
                <BsYoutube />{" "}
              </span>
            </a>
            <a
              href="NoRoomForRacism.html"
              className=" noroomforracism hide-ms navLink navOption  "
              role="button"
            >
              <div className="icn user-w show-m"></div>
              <span className="featuredLinkTitle">
                {" "}
                <BsTwitter />{" "}
              </span>
            </a>
            <a
              href="NoRoomForRacism.html"
              className=" noroomforracism hide-ms navLink navOption  "
              role="button"
            >
              <div className="icn user-w show-m"></div>
              <span className="featuredLinkTitle">
                <BsFacebook />{" "}
              </span>
            </a>
            <span className="mobile-logo">
              <a
                href="/"
                className="u-show-tab"
                aria-label="Premier League Home Page on logo link"
              >
                <img src="/assets/logo.png" style={{height:'45px'}}/>
              </a>
            </span>
          </section>
        
        </div>

        <nav className="subNav" role="menubar">
          <ul>
            <li>
              <Link
                to="/"
                className={location.pathname == "/" ? "active" : ""}
                data-link-index="0"
                style={{ fontSize: "16px" }}
                role="menuitem"
              >
                መነሻ
              </Link>
            </li>
            <li>
              <Link
                to="/newslist"
                className={
                  location.pathname == "/newslist" ||
                  location.pathname == "/news"
                    ? "active"
                    : ""
                }
                data-link-index="1"
                style={{ fontSize: "16px" }}
                role="menuitem"
              >
                ዜና
              </Link>
            </li>
            <li>
              <Link
                to="/mahber"
                className={location.pathname == "/mahber" ? "active" : ""}
                data-link-index="2"
                style={{ fontSize: "16px" }}
                role="menuitem"
              >
                ማህበራት
              </Link>
            </li>
            <li>
              <Link
                to="/tmret"
                className={location.pathname == "/tmret" ? "active" : ""}
                data-link-index="2"
                style={{ fontSize: "16px" }}
                role="menuitem"
              >
                ጥምረት
              </Link>
            </li>
            <li>
              <Link
                to="/stat"
                className={location.pathname == "/stat" ? "active" : ""}
                data-link-index="2"
                style={{ fontSize: "16px" }}
                role="menuitem"
              >
                ስታስቲክስ
              </Link>
            </li>
          </ul>
        </nav>
      </div>
    </header>
  );
}

export default NavBar;
