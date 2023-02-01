import React, { useState, useEffect } from "react";
import { Link, useLocation } from "react-router-dom";
import dateformat from "dateformat";
import { assetUrl } from "../endpoints";
import axios from "axios";
import {urlAdvert} from '../endpoints'
function NewsDetails() {
  const location = useLocation();
  const [news, setNews] = useState(location.state.news);
  const [advert, setAdvert] = useState([]);

  useEffect(() => {
    axios.get(urlAdvert).then((res) => {
      setAdvert(res.data);
      //"ggg", res.data);
    });
  }, []);

  const newsList = location.state && location.state.newsList;

  const getImage = (item) => {
    return `${assetUrl}/${item}`;
  };

  return (
    <main id="mainContent" tabIndex="0">
      <header className="articleHeader  ">
        <div className="wrapper">
          <div className="col-8">
            <div className="articleHeaderContent">
              <h5 className="newsTag">Statistics</h5>
              <h1 className="articleTitle">{news && news.title}</h1>
              <h5>
                <span className="articleAuth"></span>
                {news && dateformat(news.createdAt)}
              </h5>
            </div>
          </div>
        </div>
      </header>

      <div className="wrapper">
        <div className="col-9">
          <section
            className="standardArticle   "
            data-script="pl_news-article"
            data-widget="article-body"
            data-title="Goals galore puts scoring record under threat"
            data-id="2798649"
            data-category="Statistics"
          >
            <div className="socialShareSticky">
              <div className="socialShareHover articleShare">
                <div
                  data-script="pl_social-share"
                  data-widget="social-page-share"
                  data-open="true"
                  data-render="pagehover"
                  data-body="Goals galore puts scoring record under threat"
                ></div>
              </div>
            </div>

            <div
              data-script="pl_editorial-lists"
              data-widget="video-list"
              className="articleImage"
            >
              <img src={getImage(news.img)} alt="CHEWHU Antonio goal cropped" />
            </div>

            <h4 className="subHeader"> {news && news.subTitle} </h4>

            <div className="col-12">
              <div className="relatedArticles">
                <p className="relatedArticlesText"></p>
                <div className="relatedArticlesWrapper">
                  <div className="col-3">
                    <a className="relatedArticle text">
                      <span className="type text"></span>
                      <span className="articleLead">
                        By | {news && news.user && news.user.fullName}
                      </span>
                    </a>
                  </div>
                  <div className="col-3">
                    <a className="relatedArticle video">
                      <span className="type video"></span>
                      <span className="articleLead">
                        ON | {dateformat(news && news.createdAt)}
                      </span>
                    </a>
                  </div>
                </div>
              </div>
            </div>

            <div className="copy">
              <div>
                <div
                  dangerouslySetInnerHTML={{ __html: news.description }}
                ></div>
              </div>
            </div>
          </section>

          <section className="mainWidget latestFeatures ">
            <header>
              <h3 className="subHeader">ቅርብ ጊዜ ዜናዎች</h3>
            </header>

            <ul className="block-list-4" data-widget="lazy-load">
              {newsList.map((item, index) => (
                <li
                  key={item.id}
                  className="article-thumb js-content-load"
                  data-initialised="true"
                >
                  <a onClick={() => setNews(item)} className="thumbnail">
                    <figure>
                      <span className="image thumbCrop-latestnews">
                        <img
                          className="article-thumb__img"
                          src={getImage(item.img)}
                          alt="CHEWHU Antonio goal cropped"
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
              ተጨማሪ ዜናዎች<span className="visuallyHidden"></span>
              <span className="icn arrow-right"></span>
            </Link>
          </section>
        </div>
        <div className="col-3">
          <div className="articleSidebar">
          
           {advert.slice(0,4).map((item,index)=>
             <div className="relatedArticles" key={index}>
             <div className="partnersStrip premiumBox">
               <img style={{width:'100%'}} src={ getImage(item.adPhoto)} />
             </div>
           </div>
           )}
       


          </div>
        </div>
        <div className="col-12"></div>
      </div>
    </main>
  );
}

export default NewsDetails;
