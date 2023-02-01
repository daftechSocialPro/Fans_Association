import React, { useEffect, useState } from "react";
import axios from "axios";
import { assetUrl, urlMahber, urlMahberExec, urlTmretExec } from "../endpoints";
function Tmret() {
  const [mahber, setMahber] = useState([]);
  const [index, setIndex] = useState(0);
  const [mahberMember, setMahberMember] = useState([]);
  const [ma, setMa] = useState([]);

  useEffect(() => {
    axios
      .get(urlMahber)
      .then((res) => {
        //res.data);

        setMahber(res.data);
        setMa(res.data[0] && res.data[0]);
        //"maa", ma);
        getMahber(res.data[0] && res.data[0].id);
      })
      .catch((err) => console.error(err));
  }, []);

  const getImage = (item) => {
    return `${assetUrl}/${item}`;
  };

  const getMahber = (item) => {
    axios
      .get(`${urlTmretExec}`)
      .then((res) => setMahberMember(res.data))
      .catch((err) => console.error(err));
  };
  return (
    <div>
      <main id="mainContent" tabIndex="0">
        <header className="pageHero tabbedHero">
          <div className="wrapper col-12">
            <h1 className="pageTitle">ጥምረት</h1>
          </div>
          <nav className="heroPageLinks tabLinks" data-widget="referee-tabs">
            <ul className="wrapper col-12">
              <li data-nav-index="menuItem?index">
                <a className="btn-tab">ጥምረት</a>
              </li>
            </ul>
          </nav>
        </header>

        <div className="wrapper col-12">
          <section className="featuredArticle">
            <div className="col-10-m">
              <a className="thumbnail thumbLong">
                <figure>
                  <span
                    className="image thumbCrop-news-list"
                    style={{ width: "20%" }}
                  >
                    <img src="/assets/logo.png" alt="tmret" />
                  </span>
                  <figcaption>
                    <span className="title">
                      የኢትዮጵያ ፕሪሚየር ሊግ ደጋፊዎች ማህበራት ጥምረት
                    </span>
                    <span className="tag">
                      Established Date {ma && ma.establishedDate}
                    </span>
                    <span className="text">
                      <div>
                        በተጠናቀቀው ቤትኪንግ ኢትዮጵያ ፕሪምየር ሊግ 3ኛ ደረጃን ይዞ የፈፀመው ሲዳማ ቡና
                        በክረምቱ የተጫዋቾች የዝውውር መስኮት ራሱን ለማጠናከር ጥሮ የ2015 ውድድሩን ቢቀርብም
                        ባሰበው መንገድ መጓዝ አልቻለም። ከሦስት ጨዋታዎችም በአንዱ ብቻ ነጥብ በማሳካት በደረጃ
                        ሰንጠረዡ ግርጌ ላይ ተቀምጧል። ይህንን ተከትሎ የክለቡ ቦርድ አሠልጣኝ ወንድማገኝ ተሾመን
                        ከመንበሩ ማንሳቱ ይታወቃል።
                      </div>
                    </span>
                  </figcaption>
                </figure>
              </a>
            </div>
          </section>

          <section className="mainWidget latestFeatures ">
            <header>
              <h3 className="subHeader">የጥምረቱ ስራ አስፈጻሚዎች</h3>
            </header>

            <ul className="block-list-4" data-widget="lazy-load">
              {mahberMember.map((item) => (
                <li
                  className="article-thumb placeholder js-content-load"
                  data-initialised="false"
                >
                  <a className="thumbnail">
                    <figure>
                      <span className="image thumbCrop-latestnews" style={{borderRadius:'20px'}}>
                        <img
                          className="article-thumb__img"
                          src={getImage(item.userPhoto)}
                          alt={item.name}
                        />
                      </span>
                      <figcaption>
                        <span className="tag">አባላት</span>
                        <span className="title">{item.name}</span>
                      </figcaption>
                    </figure>
                  </a>
                  <div className="relatedArticles">
                    <a className="relatedArticle club text">
                      <p>Postition: {item.position}</p>
                    </a>

                    <a className="relatedArticle club text">
                      <p>
                        From Date :{item.fromDate} - To Date : {item.toDate}
                      </p>
                    </a>
                  </div>
                </li>
              ))}
            </ul>
          </section>
        </div>
      </main>
    </div>
  );
}

export default Tmret;
