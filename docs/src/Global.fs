module Global

open Fable.Core

type Elements =
    | Button
    | Icon
    | Title
    | Delete
    | Box
    | Content
    | Tag
    | Image
    | Progress
    | Table
    | Form
    | Notification

type Components =
    | Panel
    | Breadcrumb
    | Card
    | Media
    | Menu
    | Message
    | Navbar
    | Pagination
    | Tabs
    | Modal
    | Dropdown

type Layouts =
    | Container
    | Level
    | Hero
    | Footer
    | Section
    | Columns
    | Tile

type FulmaPage =
    | Element of Elements
    | Component of Components
    | Layout of Layouts
    | Introduction

type FulmaExtensionsPage =
    | Calendar
    | Tooltip
    | Divider
    | Introduction

type FulmaElmishPage =
    | Introduction
    | DatePicker

type Page =
    | Home
    | Fulma of FulmaPage
    | FulmaExtensions of FulmaExtensionsPage
    | FulmaElmish of FulmaElmishPage

let toHash page =
    match page with
    | Home -> "#home"
    | Fulma pageType ->
        match pageType with
        | FulmaPage.Introduction -> "#fulma"
        | Layout layout ->
            match layout with
            | Container -> "#fulma/layouts/container"
            | Level -> "#fulma/layouts/level"
            | Hero -> "#fulma/layouts/hero"
            | Footer -> "#fulma/layouts/footer"
            | Section -> "#fulma/layouts/section"
            | Tile -> "#fulma/layouts/tile"
            | Columns -> "#fulma/layouts/columns"
        | Element element ->
            match element with
            | Button -> "#fulma/elements/button"
            | Icon -> "#fulma/elements/icon"
            | Title -> "#fulma/elements/title"
            | Delete -> "#fulma/elements/delete"
            | Box -> "#fulma/elements/box"
            | Content -> "#fulma/elements/content"
            | Tag -> "#fulma/elements/tag"
            | Image -> "#fulma/elements/image"
            | Progress -> "#fulma/elements/progress"
            | Table -> "#fulma/elements/table"
            | Form -> "#fulma/elements/form"
            | Notification -> "#fulma/elements/notification"
        | Component ``component`` ->
            match ``component`` with
            | Panel -> "#fulma/components/panel"
            | Breadcrumb -> "#fulma/components/breadcrumb"
            | Card  -> "#fulma/components/card"
            | Media -> "#fulma/components/media"
            | Menu -> "#fulma/components/menu"
            | Message -> "#fulma/components/message"
            | Navbar -> "#fulma/components/navbar"
            | Pagination -> "#fulma/components/pagination"
            | Tabs -> "#fulma/components/tabs"
            | Modal -> "#fulma/components/modal"
            | Dropdown ->"#fulma/components/dropdown"
    | FulmaExtensions pageType ->
        match pageType with
        | FulmaExtensionsPage.Introduction -> "#fulma-extensions"
        | Calendar -> "#fulma-extensions/calendar"
        | Tooltip -> "#fulma-extensions/tooltip"
        | Divider -> "#fulma-extensions/divider"
    | FulmaElmish pageType ->
        match pageType with
        | FulmaElmishPage.Introduction -> "#fulma-elmish"
        | FulmaElmishPage.DatePicker -> "#fulma-elmish/date-picker"
