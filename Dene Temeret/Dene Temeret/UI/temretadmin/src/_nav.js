import React from 'react'
import CIcon from '@coreui/icons-react'
import {cilPeople, cilNewspaper, cilSpeedometer ,cilSoccer,cilBank,cilImage} from '@coreui/icons'
import { CNavItem, CNavTitle } from '@coreui/react'

const _nav = [
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
    name: 'Tmret',
  },
  {
    
    component:CNavItem,
    name:'Tmret Executives',
    to:"/tmretexec",
    icon:<CIcon icon={cilPeople} customClassName="nav-icon" />
  },
  {
    component:CNavItem,
    name:'Mahbers',
    to:"/mahber",
    icon:<CIcon icon={cilBank} customClassName="nav-icon" />
  },
  {
    component: CNavItem,
    name: 'News',
    to: '/news',
    icon: <CIcon icon={cilNewspaper} customClassName="nav-icon" />,
  },

  {
    component: CNavItem,
    name: 'Advert',
    to: '/advert',
    icon: <CIcon icon={cilImage} customClassName="nav-icon" />,
  }
]

export default _nav
