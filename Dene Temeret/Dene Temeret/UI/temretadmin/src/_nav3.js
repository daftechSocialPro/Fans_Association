import React from 'react'
import CIcon from '@coreui/icons-react'
import { cilPeople, cilSpeedometer, cilSoccer, cilAlarm, cilAirplay,
  cilAppsSettings } from '@coreui/icons'
import { CNavItem, CNavTitle } from '@coreui/react'

const _nav3 = [
  {
    component: CNavItem,
    name: 'Dashboard',
    to: '/dashboard',
    icon: <CIcon icon={cilSpeedometer} customClassName="nav-icon" />,
    badge: {
      color: 'info',
      text: 'NEW',
    },
  },
  {
    component: CNavTitle,
    name: 'Encoder',
  },

  {
    component: CNavItem,
    name: 'Team',
    to: '/team',
    icon: <CIcon icon={cilPeople} customClassName="nav-icon" />,
  },
  {
    component: CNavItem,
    name: 'Score',
    to: '/score',
    icon: <CIcon icon={cilSoccer} customClassName="nav-icon" />,
  },

  {
    component: CNavItem,
    name: 'Match',
    to: '/match',
    icon: <CIcon icon={cilAirplay} customClassName="nav-icon" />,
  },

  
  {
    component: CNavItem,
    name: 'Match Week',
    to: '/matchweek',
    icon: <CIcon icon={cilAppsSettings} customClassName="nav-icon" />,
  },
  

  {
    component: CNavItem,
    name: 'Season',
    to: '/season',
    icon: <CIcon icon={cilAlarm} customClassName="nav-icon" />,
  },
]

export default _nav3
