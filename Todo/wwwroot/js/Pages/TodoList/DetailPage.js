function ItemsList() {
    const _orderBy = function (compare) {
        const items = $('[data-item]').toArray();
        items.sort(compare);
        $('.items').empty();
        items.forEach(function (item) { $('.items').append($(item)) });
    }


    $('#displayDoneItems').change(function () { this.checked ? $('.done').show() : $('.done').hide(); });
    $('#orderBy').change(function () {
        const comparator = ItemCopmarator();
        switch ($(this).val()) {
            case 'importance':
                _orderBy(comparator.byImportance);
                break;
            case 'importance-desc':
                _orderBy(comparator.byImportanceDesc);
                break;
            case 'rank':
                _orderBy(comparator.byRank);
                break;
            case 'rank-desc':
                _orderBy(comparator.byRankDesc);
                break;
        }
    });
    
}

function ItemCopmarator() {
    const Importance = {
        "High": 0,
        "Medium": 1,
        "Low": 2
    }

    const byImportance = function (a, b) {
        return Importance[b.dataset.importance] - Importance[a.dataset.importance];
    }

    const byImportanceDesc = function (a, b) {
        return Importance[a.dataset.importance] - Importance[b.dataset.importance];
    }

    const byRank = function (a, b) {
        return a.dataset.rank - b.dataset.rank;
    }

    const byRankDesc = function (a, b) {
        return b.dataset.rank - a.dataset.rank;
    }

    return {
        byImportance,
        byImportanceDesc,
        byRank,
        byRankDesc
    }
}

function NewItemModal() {
    const show = function (e) {
        e.preventDefault();
        this.blur(); // Manually remove focus from clicked link.
        $(this).modal({ showClose: false });
    };

    const reset = function () {
        $('#Title').val('');
        $('#Importance').val('Medium');
        $('#ResponsiblePartyId').val('');
    }

    const close = function () {
        $.modal.close();
    }

    $('#create-item-action').click(show);

    return { show, close, reset };
}

ItemsList();
const modal = NewItemModal();

function closeModal() {
    modal.reset();
    modal.close();
}