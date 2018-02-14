var guitar;
var id;

//crud-------------------------------------
function createGuitar(guitar) {
    $.ajax({
        url: '/api/guitars/',
        type: 'POST',
        contentType: "application/json",
        data: JSON.stringify(guitar),
        success: function (data) {
            alert('Creating was performed.');
        }
    });
}

function updateGuitar(id, guitar) {
    $.ajax({
        url: '/api/guitars/' + id,
        type: 'PUT',
        contentType: "application/json",
        data: JSON.stringify(guitar),
        success: function (data) {
            alert('Updating was performed.');
        }
    });
}

function deleteGuitar(id) {
    $.ajax({
      url: '/api/guitars/' + id,
      type: 'DELETE',
      success: function (data) {
        location.reload();
      }
    });
  }
//------------------------------------------

function fillGuitar(){
    var brandInput = document.getElementById('brand-input');
    var modelInput = document.getElementById('model-input');
    var typeInput = document.getElementById('type-input');
    var guitar = {
        guitarId: id,
        brand: brandInput.value,
        model: modelInput.value,
        type: typeInput.value
    };
    return guitar;
}

function update() {
    var guitar = fillGuitar();
    updateGuitar(id, guitar);
    location.assign('index.html');
}

// function updateData(data) {
//     var brandInput = document.getElementById('brand-input');
//     brandInput.value = data.brand;
//     var modelInput = document.getElementById('model-input');
//     modelInput.value = data.model;
//     var typeInput = document.getElementById('type-input');
//     typeInput.value = data.type;
//     var idInput = document.getElementById('id-input');
//     idInput.Value = data.id;
// }