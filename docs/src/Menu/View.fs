module Menu.View

open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Types
open Fulma.Components
open Fulma.Elements
open Fulma.Extra.FontAwesome
open Global

let menuItem label page currentPage =
    li []
       [ a [ classList [ "is-active", page = currentPage ]
             Href(toHash page) ]
           [ str label ] ]

let menuFulma currentPage subModel dispatch =
    let (elementsClass, elementsIcon) =
        if not subModel.IsElementsExpanded then
            match currentPage with
            | Fulma (Element _) ->
                "menu-group is-active", Fa.AngleDown
            | _ -> "menu-group", Fa.AngleDown
        else
            "menu-group", Fa.AngleUp

    let (componentsClass, componentsIcon) =
        if not subModel.IsComponentsExpanded then
            match currentPage with
            | Fulma (Component _) ->
                "menu-group is-active", Fa.AngleDown
            | _ -> "menu-group", Fa.AngleDown
        else
            "menu-group", Fa.AngleUp

    let (layoutsClass, layoutsIcon) =
        if not subModel.IsLayoutExpanded then
            match currentPage with
            | Fulma (Layout _) ->
                "menu-group is-active", Fa.AngleDown
            | _ -> "menu-group", Fa.AngleDown
        else
            "menu-group", Fa.AngleUp

    [ Menu.label [ ] [ str "Fulma" ]
      Menu.list [ ]
        [ menuItem "Introduction" (Fulma FulmaPage.Introduction) currentPage ]
      Menu.list [ ]
        [ li [ ]
             [ yield a [ ClassName layoutsClass
                         OnClick (fun _ -> ToggleMenu (Library.Fulma Layouts) |> dispatch ) ]
                       [ span [ ] [ str "Layouts" ]
                         Icon.faIcon [ ] layoutsIcon ]
               if subModel.IsLayoutExpanded then
                    yield ul [ ]
                             [ menuItem "Container" (Fulma (Layout Layouts.Container)) currentPage
                               menuItem "Hero" (Fulma (Layout Layouts.Hero)) currentPage
                               menuItem "Footer" (Fulma (Layout Layouts.Footer)) currentPage
                               menuItem "Section" (Fulma (Layout Layouts.Section)) currentPage
                               menuItem "Level" (Fulma (Layout Layouts.Level)) currentPage
                               menuItem "Tile" (Fulma (Layout Layouts.Tile)) currentPage
                               menuItem "Columns" (Fulma (Layout Layouts.Columns)) currentPage ] ] ]
      Menu.list [ ]
        [ li [ ]
             [ yield a [ ClassName elementsClass
                         OnClick (fun _ -> ToggleMenu (Library.Fulma Elements) |> dispatch ) ]
                       [ span [ ] [ str "Elements" ]
                         Icon.faIcon [ ] elementsIcon ]
               if subModel.IsElementsExpanded then
                    yield ul [ ]
                             [ menuItem "Button" (Fulma (Element Elements.Button)) currentPage
                               menuItem "Icon" (Fulma (Element Elements.Icon)) currentPage
                               menuItem "Image" (Fulma (Element Elements.Image)) currentPage
                               menuItem "Title" (Fulma (Element Elements.Title)) currentPage
                               menuItem "Delete" (Fulma (Element Elements.Delete)) currentPage
                               menuItem "Progress" (Fulma (Element Elements.Progress))  currentPage
                               menuItem "Box" (Fulma (Element Elements.Box)) currentPage
                               menuItem "Content" (Fulma (Element Elements.Content))  currentPage
                               menuItem "Table" (Fulma (Element Elements.Table)) currentPage
                               menuItem "Form" (Fulma (Element Elements.Form)) currentPage
                               menuItem "Notification" (Fulma (Element Elements.Notification)) currentPage
                               menuItem "Tag" (Fulma (Element Elements.Tag)) currentPage ] ] ]
      Menu.list [ ]
        [ li [ ]
             [ yield a [ ClassName componentsClass
                         OnClick (fun _ -> ToggleMenu (Library.Fulma Components) |> dispatch ) ]
                       [ span [ ] [ str "Components" ]
                         Icon.faIcon [ ] componentsIcon ]
               if subModel.IsComponentsExpanded then
                    yield ul [ ]
                             [ menuItem "Panel" (Fulma (Component Components.Panel)) currentPage
                               menuItem "Breadcrumb" (Fulma (Component Components.Breadcrumb)) currentPage
                               menuItem "Card" (Fulma (Component Components.Card)) currentPage
                               menuItem "Media" (Fulma (Component Components.Media)) currentPage
                               menuItem "Menu" (Fulma (Component Components.Menu)) currentPage
                               menuItem "Navbar" (Fulma (Component Components.Navbar)) currentPage
                               menuItem "Pagination" (Fulma (Component Components.Pagination)) currentPage
                               menuItem "Tabs" (Fulma (Component Components.Tabs)) currentPage
                               menuItem "Message" (Fulma (Component Components.Message)) currentPage
                               menuItem "Dropdown" (Fulma (Component Components.Dropdown)) currentPage
                               menuItem "Modal" (Fulma (Component Components.Modal)) currentPage ] ] ] ]

let menuFulmaExtensions currentPage subModel dispatch =
    [ Menu.label [ ] [ str "Fulma.Extensions" ]
      Menu.list [ ]
        [ menuItem "Introduction" (FulmaExtensions FulmaExtensionsPage.Introduction) currentPage ]
      Menu.list [ ]
        [ menuItem "Calendar" (FulmaExtensions Calendar) currentPage
          menuItem "Tooltip" (FulmaExtensions Tooltip) currentPage
          menuItem "Divider" (FulmaExtensions Divider) currentPage ] ]

let menuFulmaElmish currentPage dispatch =
    [ Menu.label [ ] [ str "Fulma.Elmish" ]
      Menu.list [ ]
        [ menuItem "Introduction" (FulmaElmish FulmaElmishPage.Introduction) currentPage ]
      Menu.list [ ]
        [ menuItem "Date picker" (FulmaElmish DatePicker) currentPage ] ]

let root model dispatch =
    Menu.menu [ ]
        [ yield Menu.list [ ]
                   [ menuItem "Introduction" Home model.CurrentPage ]
          yield! menuFulma model.CurrentPage model.Fulma dispatch
          yield! menuFulmaExtensions model.CurrentPage model.FulmaExtensions dispatch
          yield! menuFulmaElmish model.CurrentPage dispatch ]
