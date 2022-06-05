$(document).ready(function () {
    $(function () {
        let current = location.pathname

        $('.sidebar .nav-sidebar .nav-item .nav-link').each(function () {
            let $this = $(this);

            // if the current path is like this link, make it active
            if ($this.attr('href') === current) {
                $this.addClass('active');

                checkMenuParentActive($this)
            }
        })
    })
})

function checkMenuParentActive(element) {
    if (element.closest('ul').hasClass('nav-treeview')) {
        let parentList = element.closest('ul').closest('li')
        let parent = parentList.find('a').first()
        parentList.addClass('menu-open')
        parent.addClass('active')

        if (parentList.closest('ul').hasClass('nav-treeview')) {
            checkMenuParentActive(element)
        }
    }
}