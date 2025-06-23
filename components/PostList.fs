module PostList

open Feliz
open PostMetadata
open Layout


[<ReactComponent>]
let PostList () =
    let posts, setPosts = React.useState<PostMeta list>([])
    let loading, setLoading = React.useState(true)

    let loadAllPosts () = async {
        let postFiles = getPostFiles() |> Array.toList
        let! metadataResults = 
            postFiles
            |> List.map loadPostMetadata
            |> Async.Parallel
        
        let validPosts = 
            metadataResults
            |> Array.choose id
            |> Array.sortByDescending (fun post -> post.date)
            |> Array.toList
        
        setPosts validPosts
        setLoading false
    }

    React.useEffect(loadAllPosts >> Async.StartImmediate, [| |])

    Layout(
        Html.div [
            prop.className "post-list"
            prop.children [
                Html.h1 "最新記事"
                
                if loading then
                    Html.p "読み込み中..."
                else
                    Html.div [
                        prop.children [
                            for post in posts do
                                Html.article [
                                    prop.className "post-summary"
                                    prop.children [
                                        Html.h2 [
                                            Html.a [
                                                let postUrl = post.filename.Replace(".adoc", "")
                                                prop.href $"/posts/{postUrl}"
                                                prop.text post.title
                                            ]
                                        ]
                                        
                                        Html.div [
                                            prop.className "post-meta"
                                            prop.children [
                                                Html.span [
                                                    prop.className "post-date" 
                                                    prop.text post.date
                                                ]
                                                match post.author with
                                                | Some author ->
                                                    Html.span [
                                                        prop.className "post-author"
                                                        prop.text $" by {author}"
                                                    ]
                                                | None -> Html.none
                                            ]
                                        ]
                                        
                                        match post.summary with
                                        | Some summary ->
                                            Html.p [
                                                prop.className "post-summary-text"
                                                prop.text summary
                                            ]
                                        | None -> Html.none
                                    ]
                                ]
                        ]
                    ]
            ]
        ]
    )