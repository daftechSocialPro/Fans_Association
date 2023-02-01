import React, { useState, useEffect,useRef } from "react";
import { useNavigate, Link } from "react-router-dom";
import Sidebar from "./Sidebar";
import axios from "axios";
import { urlNews, assetUrl, urlHub, urlAdvert } from "../endpoints";

function Hero( {connection}) {
  const [news, setNews] = useState([]);
  const [mnews, setMnews] = useState([]);

  const [hnews, setHnews] = useState([]);

  const navigate = useNavigate();

  const [advert,setAdvert]=useState([]);


  useEffect(() => {
    axios.get(`${urlNews}`).then((res) => {
      //res.data);

      setNews(res.data.filter((x) => x.user.userRole === 0));
      setMnews(res.data.filter((x) => x.user.userRole === 1));
      setHnews(res.data.filter((x) => x.isHeadLine));
    });
    axios.get(`${urlAdvert}`).
    then((res) => {
      setAdvert(res.data)
    }).catch((err)=>console.error(err));
  }, []);

  if (connection) {
    connection.on("getNews", (result) => {
      setNews(result);
      setMnews(result.filter((x) => x.user.userRole === 1));
      setHnews(result.filter((x) => x.isHeadLine));      
    });
  }
 

  const getImage = (item) => {
    const imagePath = `${assetUrl}/${item}`;

    return imagePath;
  };

  const newsDetails = (e, item) => {
    e.preventDefault();
    //item);

    navigate("news", {
      state: {
        news: item,
        newsList: news.slice(0, 6),
      },
    });
  };

  const Clubs = [];
  return (
    <main id="mainContent">
      <div className="wrapper hasFixedSidebar">
        <Sidebar connection={connection} />
        <div className="sidebarPush">
          <div className="col-12">
            <svg
              style={{ width: "0", height: "0", position: "absolute" }}
              aria-hidden="true"
              focusable="false"
            >
              <linearGradient id="gradient--pinkLilac" x2="1" y2="1">
                <stop offset="0%" stopColor="#e4dfeb"></stop>
                <stop offset="100%" stopColor="#a18d8d"></stop>
              </linearGradient>

              <linearGradient id="gradient--orangePink" x2="1" y2="1">
                <stop offset="0%" stopColor="#a18d8d"></stop>
                <stop offset="100%" stopColor="#5f4a1e"></stop>
              </linearGradient>

              <linearGradient id="gradient--purpleGreen" x2="1" y2="1">
                <stop offset="0%" stopColor="#106e07"></stop>
                <stop offset="100%" stopColor="#a18d8d"></stop>
              </linearGradient>

              <linearGradient id="gradient--purpleBlue" x2="1" y2="1">
                <stop offset="0%" stopColor="#106e07"></stop>
                <stop offset="100%" stopColor="#a18d8d"></stop>
              </linearGradient>

              <linearGradient id="gradient--blueLilac" x2="1" y2="1">
                <stop offset="0%" stopColor="#a18d8d"></stop>
                <stop offset="100%" stopColor="#a18d8d"></stop>
              </linearGradient>

              <linearGradient id="gradient--greenBlue" x2="1" y2="1">
                <stop offset="0%" stopColor="#a18d8d"></stop>
                <stop offset="100%" stopColor="#a18d8d"></stop>
              </linearGradient>
            </svg>

            <section
              className="hero-playlist theme--pinkLilac "
              data-widget="hero"
              data-script="pl_hero"
            >
              <svg
                className="hero-playlist__bg-shape"
                version="1.1"
                id="Layer_1"
                xmlns="http://www.w3.org/2000/svg"
                x="0px"
                y="0px"
                viewBox="0 0 1432 524"
              >
                <linearGradient
                  id="SVGID_1_"
                  gradientUnits="userSpaceOnUse"
                  x1="1348.4205"
                  y1="329.9624"
                  x2="495.7404"
                  y2="481.3125"
                  gradientTransform="matrix(1 0 0 -1 0 524)"
                >
                  <stop offset="0" style={{ stopColor: "#5f4a1e" }}></stop>
                  <stop offset="1" style={{ stopColor: "#e0d55d" }}></stop>
                </linearGradient>
                <path
                  className="st0__hero"
                  d="M1432,0v139.9c-216.6,90.1-456.5,139.8-705.3,139.8c-35.3,0-42.6,1.1-77.4-0.9l107.6-108.2 c-195.9,0-406.8-27.2-583.9-84.3l75.3-75.7C235.3,7.3,222.3,3.7,209.4,0h665.7l-58.8,59.1c97.9-10.3,199.5-30.7,298.2-59.1H1432z"
                ></path>
                <linearGradient
                  id="SVGID_2_"
                  gradientUnits="userSpaceOnUse"
                  x1="1344.87"
                  y1="0.2301"
                  x2="339.98"
                  y2="178.5901"
                  gradientTransform="matrix(1 0 0 -1 0 524)"
                >
                  <stop offset="0" style={{ stopColor: "#5f4a1e" }}></stop>
                  <stop offset="1" style={{ stopColor: "#e0d55d" }}></stop>
                </linearGradient>
                <path
                  className="st1__hero"
                  d="M1432,352.2V524H292.3c-7.2-2.2-14.3-4.4-21.4-6.7l75.3-75.7C227.1,410.8,107.7,364.1,0,310V169 c156.8,62.4,340.5,93.9,517.8,100L439,348.3c110.4,23.9,216.9,35.8,334.4,35.8c101.7,0,170.9-3.2,267.4-21.2L914.3,490.1 C1087.4,471.9,1271.8,422.3,1432,352.2z"
                ></path>
              </svg>

              <div className="hero-playlist__thumbnail">
                <figure className="hero-playlist__thumbnail-figure">
                  <a
                    onClick={(e) => newsDetails(e, hnews[0] && hnews[0])}
                    className="image hero-playlist__thumbnail-image  "
                  >
                    <picture className="hof-featured-player__player-image">
                      <source
                        media="(min-width: 1101px)"
                        srcSet={getImage(hnews[0] && hnews[0].img)}
                      />
                      <img
                        src={getImage(hnews[0] && hnews[0].img)}
                        alt={hnews[0] && hnews[0].title}
                      />
                    </picture>
                  </a>

                  <figcaption>
                    <span className="hero-playlist__thumbnail-tag">
                      Feature
                    </span>
                    <h4 className="hero-playlist__thumbnail-title">
                      <a onClick={(e) => newsDetails(e, hnews[0] && hnews[0])}>
                        {hnews[0] && hnews[0].title}
                      </a>
                    </h4>
                    <p>{hnews[0] && hnews[0].subTitle}</p>

                    <h5 style={{ fontSize: "16px" }} className="related-title">
                      ተዛማጅ ይዘት
                    </h5>

                    <div>
                      {news.slice(0, 3).map((item,index) => (
                        <div key={index} className="related-item">
                          <a
                            onClick={(e) => newsDetails(e, item)}
                            className="relatedArticle club text"
                          >
                            <p style={{ fontSize: "14px" }}>{item.title}</p>
                          </a>
                        </div>
                      ))}
                    </div>
                  </figcaption>
                </figure>
              </div>

              <div className="hero-playlist__secondary-thumbnail-wrapper">
                <div className="hero-playlist__thumbnail hero-playlist__thumbnail--secondary">
                <figure className="hero-playlist__thumbnail-figure">
                    <a
                      onClick={(e) => newsDetails(e, news[0] && news[0])}
                      className="image hero-playlist__thumbnail-image  "
                    >
                      <img
                        src={news[0] && getImage(news[0].img)}
                        alt={news[0]&&news[0].title}
                      />
                    </a>

                    <figcaption>
                      <span
                        className="hero-playlist__thumbnail-tag"
                        style={{ fontSize: "14px" }}
                      >
                        ዜና
                      </span>
                      <h4 className="hero-playlist__thumbnail-title">
                        <a onClick={(e) => newsDetails(e, news[0] && news[0])}>
                          {news[0] && news[0].title}
                        </a>
                      </h4>
                    </figcaption>
                  </figure>
                </div>

                <div className="hero-playlist__thumbnail hero-playlist__thumbnail--secondary">
                  <figure className="hero-playlist__thumbnail-figure">
                    <a
                      onClick={(e) => newsDetails(e, news[1] && news[1])}
                      className="image hero-playlist__thumbnail-image  "
                    >
                      <img
                        src={news[1] && getImage(news[1].img)}
                        alt={news[1]&&news[1].title}
                      />
                    </a>

                    <figcaption>
                      <span
                        className="hero-playlist__thumbnail-tag"
                        style={{ fontSize: "14px" }}
                      >
                        ዜና
                      </span>
                      <h4 className="hero-playlist__thumbnail-title">
                        <a onClick={(e) => newsDetails(e, news[1] && news[1])}>
                          {news[1] && news[1].title}
                        </a>
                      </h4>
                    </figcaption>
                  </figure>
                </div>
              </div>
            </section>

            <div className="partnersStrip premiumBox">
             {advert.filter(x=>x.postition==2)[0]&& <img width='100%'   src={getImage( advert.filter(x=>x.postition==2)[0]&&advert.filter(x=>x.postition==2)[0].adPhoto)} />
           
                      }</div>

            <section className="mainWidget latestFeatures ">
              <header>
                <h3 className="subHeader">አዳዲስ ዜናዎች</h3>
              </header>

              <ul className="block-list-3" data-widget="lazy-load">
                {news.map((item,index) => (
                  <li
                    key={index}
                    className="article-thumb js-content-load"
                    data-initialised="true"
                  >
                    <a
                      onClick={(e) => newsDetails(e, item)}
                      className="thumbnail"
                    >
                      <figure>
                        <span className="image thumbCrop-latestnews">
                          <img
                            className="article-thumb__img"
                            src={getImage(item.img)}
                            alt={item.title}
                          />
                        </span>
                        <figcaption>
                          <span className="tag">ስታትስቲክስ</span>
                          <span className="title">{item.title}</span>
                        </figcaption>
                      </figure>
                    </a>
                    <div className="relatedArticles">
                      <a className="relatedArticle club text">
                        <p>{item.subTitle}</p>
                      </a>
                    </div>
                  </li>
                ))}
              </ul>

              <Link className="btn moreBtn widget-button" to="/newslist">
                ተጨማሪ ዜናዎች<span className="visuallyHidden">: ተጨማሪ ዜናዎች </span>
                <span className="icn arrow-right"></span>
              </Link>
            </section>

            <section className="bespokePromo nikeBallHubPromo mainWidget mainWidget--no-ws">
              <div className="wrapper col-12">
                <div className="bespokePromoImageContainer ballContainer">
                  <img
                    src="/assets/i/nike-ball-hub/combined_ball_image.png"
                    alt="2022 Nike Ball"
                    className="ball"
                  />
                </div>
                <div className="info">
                  <h3>የኢትዮጵያ ፕሪሚየር ሊግ ደጋፊዎች ማህበር</h3>
                  <p>
                    ሳከሦስት የውድድር ዘመናት በኋላ ዓምና ዳግም የሊጉን ዘውድ የደፉት ፈረሰኞቹ ፈረሰኞቹ በተረጋጋ
                    ሳከሦስት የውድድር ዘመናት በኋላ ዓምና ዳግም የሊጉን ዘውድ የደፉት ፈረሰኞቹ ፈረሰኞቹ በተረጋጋ
                    ሳከሦስት የውድድር ዘመናት በኋላ ዓምና ዳግም{" "}
                  </p>
                  <a href="nike-ball-hub.html" className="btn">
                    ያስሱ<span className="icn arrow-right"></span>
                  </a>
                </div>
              </div>
            </section>

            <section className="mainWidget latestFeatures ">
              <header>
                <h3 className="subHeader">የክለብ ማህበር ዜና</h3>
              </header>

              <ul className="block-list-4" data-widget="lazy-load">
                {mnews.map((item,index) => (
                  <li
                    key={index}
                    className="article-thumb js-content-load"
                    data-initialised="true"
                  >
                    <a
                      onClick={(e) => newsDetails(e, item)}
                      className="thumbnail"
                    >
                      <figure>
                        <span className="image thumbCrop-latestnews">
                          <img
                            className="article-thumb__img"
                            src={getImage(item.img)}
                            alt={item.title}
                          />
                        </span>
                        <figcaption>
                          <span className="tag">By | {item.user&&item.user.fullName}</span>
                          <span className="title">{item.title} </span>
                        </figcaption>
                      </figure>
                    </a>
                  
                    <div className="relatedArticles">
                      <a className="relatedArticle club text">
                        <p>{item.subTitle}</p>
                      </a>
                    </div>
                  </li>
                ))}
              </ul>

              <Link className="btn moreBtn widget-button" to="/newslist">
                ተጨማሪ ዜናዎች<span className="visuallyHidden">: ተጨማሪ ዜናዎች </span>
                <span className="icn arrow-right"></span>
              </Link>
            </section>

            <div className="partnersStrip premiumBox">
            {advert.filter(x=>x.postition==3)[0]&& <img width='100%'  src={getImage( advert.filter(x=>x.postition==3)[0]&&advert.filter(x=>x.postition==3)[0].adPhoto)} />
}
           </div>
          </div>
        </div>
      </div>
    </main>
  );
}

export default Hero;
