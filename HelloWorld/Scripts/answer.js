window.module = {
    Answer: function (AuthorName) {
        var elem  = document.getElementById('comment-textarea');
        elem.value = AuthorName + ", ";
        window.scrollTo(0,0);
    }
}

