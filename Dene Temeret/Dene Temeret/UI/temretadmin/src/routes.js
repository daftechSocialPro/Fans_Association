import React from 'react'

const Dashboard = React.lazy(() => import('./views/dashboard/Dashboard'))

const TmretExec = React.lazy(() => import('./views/tmret/tmretexec/TmretExec'))
const TmretExecCreate = React.lazy(() => import('./views/tmret/tmretexec/TmretExecCreate'))
const TmretExecEdit = React.lazy(() => import('./views/tmret/tmretexec/TmretExecEdit'))

const Mahber = React.lazy(() => import('./views/tmret/mahber/Mahber'))
const MahberProfile = React.lazy(() => import('./views/tmret/mahber/MahberProfile'))

const NewsCreate = React.lazy(() => import('./views/tmret/news/NewsCreate'))
const News = React.lazy(() => import('./views/tmret/news/News'))
const NewsEdit = React.lazy(() => import('./views/tmret/news/NewsEdit'))

const Advert = React.lazy(() => import('./views/tmret/advert/Advert'))

const VideoCreate = React.lazy(() => import('./views/video/VideosCreate'))
const Video = React.lazy(() => import('./views/video/Videos'))

const Member = React.lazy(() => import('./views/member/Member'))
const MemberCreate = React.lazy(() => import('./views/member/MemberCreate'))

const Match = React.lazy(() => import('./views/encoder/match/Match'))
const MatchCreate = React.lazy(() => import('./views/encoder/match/MatchCreate'))
const MatchUpdate = React.lazy(() => import('./views/encoder/match/MatchEdit'))

const MahberExec = React.lazy(() => import('./views/mahber/mahberexec/MahberExec'))
const MahberExecCreate = React.lazy(() => import('./views/mahber/mahberexec/MahberExecCreate'))
const MahberExecEdit = React.lazy(() => import('./views/mahber/mahberexec/MahberExecEdit'))

const DegafiSettting = React.lazy(() => import('./views/mahber/degafi/DegafiSetting'))

const Degafi = React.lazy(() => import('./views/mahber/degafi/degafi/Degafi'))
const Degaficreate = React.lazy(() => import('./views/mahber/degafi/degafi/DegafiCreate'))
const DegafiEdit = React.lazy(() => import('./views/mahber/degafi/degafi/DegafiEdit'))

const Season = React.lazy(() => import('./views/encoder/season/Season'))
const Team = React.lazy(() => import('./views/encoder/team/Team'))
const MatchWeek = React.lazy(() => import('./views/encoder/matchweek/MatchWeek'))
const Score = React.lazy(() => import('./views/encoder/Score/Score'))

const PlayerCreate = React.lazy(()=>import('./views/encoder/players/PlayerCreate'))
const Player = React.lazy(()=>import('./views/encoder/players/Player') )
const PlayerEdit = React.lazy(()=>import('./views/encoder/players/PlayerEdit'))

const FanPayment = React.lazy(()=>import('./views/mahber/fanpayemnt/FanPayment'))
const FanPaymentsModal = React.lazy(()=>import('./views/mahber/fanpayemnt/FanPaymentsModal'))
const routes = [
  { path: '/', exact: true, name: 'Home' },
  { path: '/dashboard', name: 'Dashboard', element: Dashboard },

  //tmretexec
  { path: '/tmretexec', name: 'Tmret Executives', exact: true, element: TmretExec },
  { path: '/tmretexec/create', name: 'Add Tmret Executives', element: TmretExecCreate },
  { path: '/tmretexec/edit', name: 'Edit Tmret Executives', element: TmretExecEdit },

  //mahber
  { path: '/mahber', name: 'mahber', element: Mahber, exact: true },
  { path: '/mahber/profile', name: 'Profile', element: MahberProfile },

  //news
  { path: '/news', name: 'News', element: News, exact: true },
  { path: '/news/create', name: 'Add News', element: NewsCreate },
  { path: '/news/edit', name: 'Edit News', element: NewsEdit },

  //advert
  { path: '/advert', name: 'Advert', element: Advert, exact: true },

  //videos
  { path: '/videos', name: 'Video', element: Video, exact: true },
  { path: '/videos/create', name: 'Add Video', element: VideoCreate },

  //member
  { path: '/members', name: 'Members', element: Member, exact: true },
  { path: '/members/create', name: 'Add Member', element: MemberCreate },

  //member
  { path: '/match', name: 'Match', element: Match, exact: true },
  { path: '/match/create', name: 'Add Match', element: MatchCreate },
  { path: '/match/update', name: 'Update Match', element: MatchUpdate },

  //mahber
  //degafi setting
  { path: '/mahber/degafisetting', name: 'Fans Setting', element: DegafiSettting },
  { path: '/mahber/fanpayment', name:'Fans Payment', element:FanPayment},
  { path: '/mahber/fanpaymentmodal', name:'Fan Payment', element:FanPaymentsModal},

  //degafi

  { path: '/degafi', name: 'Fans', exact: true, element: Degafi },
  { path: '/degafi/create', name: 'Add Fan', element: Degaficreate },
  { path: '/degafi/edit', name: 'Edit Fan', element: DegafiEdit },

  //mahberexec
  { path: '/mahberexec', name: 'Mahber Executives', exact: true, element: MahberExec },
  { path: '/mahberexec/create', name: 'Add Mahber Executives', element: MahberExecCreate },
  { path: '/mahberexec/edit', name: 'Edit Mahber Executives', element: MahberExecEdit },

  //enocder
  //season
  { path: '/season', name: 'Season', element: Season },

  //team
  { path: '/team', name: 'Team', element: Team },

  //match week

  { path: '/matchweek', name: 'Match Week', element: MatchWeek },
  //score
  { path: '/score', name: 'Score', element: Score },
  //playerCreate 
  {path: '/player/playerCreate', name:'Player Create', element: PlayerCreate},
  {path:'/player',name:Player,element:Player},
  {path:'/player/playerEdit', name:"Player Edit", element:PlayerEdit}
]

export default routes
