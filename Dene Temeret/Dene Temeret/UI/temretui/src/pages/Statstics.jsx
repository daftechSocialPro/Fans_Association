import axios from "axios";
import React, { useState, useEffect } from "react";
import { assetUrl, urlDashboard } from "../endpoints";

import DOMPurify from "dompurify";
function Statstics() {
  const [table, setTable] = useState([]);
  const [expanded,setExpanded]=useState(-1)

  useEffect(() => {
    axios
      .get(`${urlDashboard}/table`)
      .then((res) => {
        setTable(res.data);
        //"user Table", table);
      })
      .catch((err) => console.error(err));
  }, []);

  const getImage = (item) => {
    return `${assetUrl}/${item}`;
  };

  return (
    <>
      <header className="pageHero tabbedHero ">
        <div className="wrapper col-12">
          <h1 className="pageTitle">ስታስቲክስ</h1>
          <div
            data-script="pl_tabbed"
            data-widget="tabbed-content"
            className="tabLinks left"
            data-tab-wrap=".tabs"
            data-tab-class="mainTableTab"
            data-update-tab-param="true"
          >
            <div className="tabs">
              <ul className="tablist" role="tablist">
                <li
                  role="tab"
                  tabIndex="0"
                  data-tab-index="0"
                  className="active"
                >
                  ማህበራት
                </li>
              </ul>
            </div>
          </div>
        </div>
      </header>

      <div className="wrapper col-12 tableHeader">
        <div className="tableLogo">
          <div className="competitionImage1"></div>
        </div>
        <div className="liveLeague toggle-btn js-live-toggle-container is-active u-hide">
          <div className="live-animation">
            <span></span>
          </div>
          <span>
            <span className="liveLeague__live"> Live</span> League Table
          </span>
          <button className="toggle-btn__toggle js-live-toggle">
            <span className="toggle-btn__ball"></span>
          </button>
        </div>
      </div>

      <div className="wrapper col-12">
        <div className="roundsContainer toggle"></div>
        <div className="allStructureContainer"></div>
      </div>

      <div className="allTablesContainer">
        <div className="wrapper col-12">
          <div className="tableContainer">
            <div className="table wrapper col-12">
              <summary className="visuallyHidden">
                This table charts the Premier League teams
              </summary>
              <table>
                <thead>
                  <tr>
                    <th className="revealMoreHeader text-centre" scope="col">
                      ተጨማሪ
                    </th>
                    <th className="text-centre" scope="col">
                      <div className="thFull">ደረጃ</div>
                    </th>
                    <th className="team" scope="col">
                      ማህበር
                    </th>
                    <th scope="col">
                      <div className="thFull">ማህበር ተለዋጭ ስም</div>
                    </th>
                    <th scope="col">
                      <div className="thFull">ማህበር ስራ አስፈጻሚዎች ብዛት</div>
                    </th>
                    <th scope="col">
                      <div className="thFull">ደጋፊ ብዛት</div>
                    </th>
                    <th scope="col">
                      <div className="thFull">ምስረታ ቀን</div>
                    </th>
                  </tr>
                </thead>
                <tbody>
                  {table.map((item, index) => (
                    <>
                      <tr  className={index===expanded?"tableDark expanded":"tableDark"}>
                        <td onClick={()=>setExpanded( expanded===index?-1:index)} className="revealMore" tabIndex="0" role="button">
                          <div   className="icn chevron-downgrey-normal"></div>
                        </td>
                        <td
                          className="pos button-tooltip"
                          tabIndex="0"
                          id="Tooltip"
                        >
                          <span className="value">{index + 1}</span>
                          <span className="movement  none">
                            <span
                              className="tooltipContainer tooltip-left"
                              role="tooltip"
                            >
                              <span className="tooltip-content">
                                Previous Position
                                <span className="resultHighlight">1</span>
                              </span>
                            </span>
                          </span>
                        </td>
                        <td className="team" scope="row">
                          <a>
                            <span
                              className="badge badge-image-container"
                              data-widget="club-badge-image"
                              data-size="25"
                            >
                              <img
                                className="badge-image badge-image--25"
                                src={getImage(item.image)}
                              />
                            </span>
                            <span className="long">{item.mahberName}</span>
                          </a>
                        </td>

                        <td>{item.mahberAltName}</td>
                        <td>
                          {item.mahberExecutives &&
                            item.mahberExecutives.length}
                        </td>
                        <td>{item.numberOfDegafi}</td>
                        <td>{item.establishedDate}</td>
                      </tr>

                      <tr className="expandable">
                        <td colSpan="13">
                          <a
                            href="/clubs/1/Arsenal/overview"
                            className="expandableTeam"
                          >
                            <span
                              className="badge badge-image-container"
                              data-widget="club-badge-image"
                              data-size="50"
                            >
                              <img
                                className="badge-image badge-image--50"
                                src={getImage(item.image)}
                              />
                            </span>
                            <span className="teamName">
                              {item.mahberName} ({item.mahberAltName})
                            </span>
                          </a>
                          <div className="expandableFixtures">
                            <div className="btnContainer">
                              <a
                                href={item.website}
                                className="btn-highlight"
                                role="btn"
                                target="_blank"
                              > 
                                የማህበር{" "}
                                <span className="visuallyHidden">
                                  {item.mahberName}{" "}
                                </span>{" "}
                                ገጽን ይጎብኙ
                                <span className="icn arrow-rightwhite"></span>
                              </a>
                            </div>
                          </div>
                          <div className="teamPerformanceStandingsArea">
                            <header>
                              <h3 className="subHeader left">
                                የማህበር ስራ አስፈጻሚዎች
                              </h3>
                            </header>
                            <div className="teamPerformanceStandingsContainer">
                              <table>
                                <thead>
                                  <tr>
                                    <th className="text-centre" scope="col">
                                      <div className="thFull">#</div>
                                    </th>

                                    <th className="team" scope="col">
                                      ስም
                                    </th>
                                    <th scope="col">
                                      <div className="thFull">የስራ ዘመን</div>
                                    </th>
                                    <th scope="col">
                                      <div className="thFull">ዝርዝር</div>
                                    </th>
                                  </tr>
                                </thead>

                                <tbody>
                                  {item.mahberExecutives.map((ite, inde) => (
                                    <tr key={inde}>
                                      <td>
                                        <span className="value">
                                          {inde + 1}
                                        </span>
                                      </td>
                                      <td className="team" scope="row">
                                        <span
                                          className="badge badge-image-container"
                                          data-widget="club-badge-image"
                                          data-size="25"
                                        >
                                          <img
                                            className="badge-image badge-image--25"
                                            src={getImage(ite.userPhoto)}
                                          />
                                        </span>
                                        <span className="long">{ite.name}</span>
                                      </td>

                                      <td className="thFull">
                                        ክ {ite.fromDate} እስከ {ite.toDate}
                                      </td>

                                      <td className="team">
                                        <div
                                          dangerouslySetInnerHTML={{
                                            __html: `${DOMPurify.sanitize(
                                              ite.description
                                            ).slice(0, 200)}`,
                                          }}
                                        ></div>
                                      </td>
                                    </tr>
                                  ))}
                                </tbody>
                              </table>
                            </div>
                          </div>
                        </td>
                      </tr>
                    </>
                  ))}
                </tbody>
              </table>
            </div>
          </div>
        </div>
      </div>
    </>
  );
}

export default Statstics;
