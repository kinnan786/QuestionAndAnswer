// JavaScript Document
// <script language="JavaScript1.2" type="text/JavaScript">
// Copyright (c)2005 Rewritten Software.  http://www.rewrittensoftware.com
// This script is supplied "as is" witrhout any form of warranty. Rewritten Software 
// shall not be liable for any loss or damage to person or property as a result of using this script.
// Use this script at your own risk!
// You are licensed to use this script free of charge for commercial or non-commercial use providing you do not remove 
// the copyright notice or disclaimer.

// Define the array that will contain the mapping table for ids to images.
var iconMap = new Array();
var iconList = new Array(iconMap);

function Toggle(item) {
    var idx = -1;
    for (i = 0; i < iconList.length; i++) {
        if (iconList[i][0] == item) {
            idx = i;
            break;
        }
    }

    //    if (idx < 0)
    //        alert("Could not find key in Icon List.");

    var div = document.getElementById("D" + item);
    var visible = (div.style.display != "none");
    var key = document.getElementById("P" + item);


    // Check if the item clicked has any children. If it does not then remove the plus/minus icon
    // and replace it with a transaparent gif.
    var hasChildren = div.hasChildNodes();
    var removeIcon = hasChildren == false;
    if (!hasChildren) {
        var childpopulate = div.getAttribute("ChildPopulated");
        //alert(childpopulate == "0");
        if (childpopulate == "0") {
            if (window.populateChild) {
                var rtn = populateChild(item) // method in form to retrieve child and popolate
                if (rtn == "0") // success
                {
                    div.setAttribute("ChildPopulated", "1");
                    removeIcon = false;
                }
            }
        }
    }


    if (key != null) {
        if (!removeIcon) {
            if (visible) {
                div.style.display = "none";
                key.innerHTML = "<img src='" + plusImagePath + "' width='6' height='8' hspace='0' vspace='0' border='0'>";
            }
            else {
                div.style.display = "block";
                key.innerHTML = "<img src='" + minusImagePath + "' width='6' height='8' hspace='0' vspace='0' border='0'>";
            }
        }
        else
            key.innerHTML = "<img src='" + transparentImagePath + "' width='6' height='8' hspace='0' vspace='0' border='0'>";
    }

    // Toggle the icon for the tree item
    //    key = document.getElementById("I" + item);
    //    if (key != null) {
    //        if (visible) {
    //            div.style.display = "none";
    //            key.innerHTML = "<img src='" + iconList[idx][1] + "' width='6' height='8' hspace='0' vspace='0' border='0'>";
    //        }
    //        else {
    //            div.style.display = "block";
    //            key.innerHTML = "<img src='" + iconList[idx][2] + "' width='6' height='8' hspace='0' vspace='0' border='0'>";
    //        }
    //    }
}

// not used
function Expand() {
    divs = document.getElementsByTagName("DIV");
    for (i = 0; i < divs.length; i++) {
        divs[i].style.display = "block";
        key = document.getElementById("x" + divs[i].id);
        key.innerHTML = "<img src='img/textfolder.gif' width='6' height='8' hspace='0' vspace='0' border='0'>";
    }
}

// not used
function Collapse() {
    divs = document.getElementsByTagName("DIV");
    for (i = 0; i < divs.length; i++) {
        divs[i].style.display = "none";
        key = document.getElementById("x" + divs[i].id);
        key.innerHTML = "<img src='img/folder.gif' width='6' height='8' hspace='0' vspace='0' border='0'>";
    }
}

function AddImage(parent, imgFileName) {
    img = document.createElement("IMG");
    img.setAttribute("src", imgFileName);
    img.setAttribute("width", 16);
    img.setAttribute("height", 16);
    img.setAttribute("hspace", 0);
    img.setAttribute("vspace", 0);
    img.setAttribute("border", 0);
    parent.appendChild(img);
    return img;
}
function AddImage2(parent, imgFileName, width, height, paddingTop) {
    img = document.createElement("IMG");
    img.setAttribute("src", imgFileName);
    img.setAttribute("width", width);
    img.setAttribute("height", height);
    img.setAttribute("paddingTop", paddingTop);
    img.setAttribute("hspace", 0);
    img.setAttribute("vspace", 0);
    img.setAttribute("border", 0);
    parent.appendChild(img);
    return img;
}

function CreateUniqueTagName(seed) {
    var tagName = seed;
    var attempt = 0;

    if (tagName == "" || tagName == null)
        tagName = "x";

    while (document.getElementById(tagName) != null) {
        tagName = "x" + tagName;
        if (attempt++ > 50) {
            alert("Cannot create unique tag name. Giving up. \nTag = " + tagName);
            break;
        }
    }

    return tagName;
}


var inactive = false; // set from caller script 

function CreateTreeItemLibrary(parent, img1FileName, img2FileName, nodeID, nodeName, url, target, cssClass, ShowImageAhead, showPreviewIcon, hasChild, selectBox) {
    CreateTreeItem(parent, img1FileName, img2FileName, nodeID, nodeName, url, target, cssClass, ShowImageAhead, showPreviewIcon, hasChild, false, "", selectBox, false)
}

function CreateTreeItem(parent, img1FileName, img2FileName, nodeID, nodeName, url, target, cssClass, ShowImageAhead, showPreviewIcon, hasChild, draggable) {
    CreateTreeItem(parent, img1FileName, img2FileName, nodeID, nodeName, url, target, cssClass, ShowImageAhead, showPreviewIcon, hasChild, draggable, "", false, false)
}
// Creates a new package under a parent. 
// Returns a TABLE tag to place child elements under.
function CreateTreeItem(parent, img1FileName, img2FileName, nodeID, nodeName, url, target, cssClass, ShowImageAhead, showPreviewIcon, hasChild, draggable, deleteImagePath, selectBox, isSelectBoxChecked) {
    var uniqueId = CreateUniqueTagName(nodeID);
    for (i = 0; i < iconList.length; i++)
        if (iconList[i][0] == uniqueId) {
            // alert("Non unique ID in Element Map. '" + uniqueId + "'");
            // return;
        }

    iconList[iconList.length] = new Array(uniqueId, img1FileName, img2FileName);
    table = document.createElement("TABLE");
    if (parent != null)
        parent.appendChild(table);

    table.setAttribute("border", 0);
    table.setAttribute("cellpadding", 0);
    table.setAttribute("cellspacing", 0);
    table.setAttribute("width", "100%");
    table.setAttribute("id", "Tab_" + uniqueId);
    table.setAttribute("parentID", parent.id);

    tablebody = document.createElement("TBODY");
    table.appendChild(tablebody);

    table.onselectstart = function () {
        if (dragObject != null)
            return false;
    };

    table.onmouseover = function () {

        //var obj =document.getElementById("P" + uniqueId);
        //var path = obj.childNodes[0].getAttribute("src"); path = path.replace("plus.png", "plusOver.png"); path = path.replace("minus.png", "minusOver.png"); obj.childNodes[0].setAttribute("src", path);
        this.style.backgroundImage = "url(" + mounseOverImagePath + ")"; this.style.backgroundPosition = "top left"; this.style.backgroundRepeat = "repeat-x";
    };
    table.onmouseout = function () {

        //var obj = document.getElementById("P" + uniqueId);
        //var path = obj.childNodes[0].getAttribute("src"); path = path.replace("plusOver.png", "plus.png"); path = path.replace("minusOver.png", "minus.png"); obj.childNodes[0].setAttribute("src", path);
        this.style.backgroundImage = "";
    };

    if (!inactive) {
        if (draggable)
            makeDraggable(table);
    }

    row = document.createElement("TR");
    //row.onmouseover = function () { this.style.backgroundImage = "url(" + mounseOverImagePath + ")"; this.style.backgroundPosition = "top left"; this.style.backgroundRepeat = "repeat-x"; };
    //row.onmouseout = function () { this.style.backgroundImage = ""; };
    if (!inactive) {
        row.onclick = function () { Toggle(uniqueId); };
    }
    row.setAttribute("width", "100%");
    row.setAttribute("id", "TR_" + uniqueId);

    tablebody.appendChild(row);

    // Create the cell for some spacing
    cell = document.createElement("TD");
    cell.setAttribute("width", 10);
    row.appendChild(cell);

    //deleteImagePath, selectBox, isSelectBoxChecked

    if (typeof (deleteImagePath) != "undefined" && deleteImagePath != "" && deleteImagePath != null) {   // Create the cell for DeleteIamge        
        cell = document.createElement("TD");
        cell.setAttribute("width", 10);
        row.appendChild(cell);

        var imgDelete = AddImage2(cell, deleteImagePath, 8, 8, 0);
        imgDelete.onmouseover = function () { this.style.cursor = "Hand"; };
        imgDelete.onmouseout = function () { this.style.cursor = "auto"; };
        imgDelete.setAttribute("id" + "del_" + uniqueId);
        imgDelete.onclick = function () {
            if (window.DeleteTreeNode) {
                DeleteTreeNode(uniqueId);
            }
            cancelEvent(window.event)
        }
    }


    if (typeof (selectBox) != "undefined") {   // Create the cell for DeleteIamge
        if (selectBox == true) {
            cell = document.createElement("TD");
            cell.setAttribute("width", 10);
            row.appendChild(cell);

            var chkBox = document.createElement("input");
            chkBox.type = "checkbox";
            chkBox.style.border = "none";
            chkBox.style.position = "relative";
            chkBox.style.left = "-6px";
            chkBox.style.top = "-4px";
            chkBox.style.zIndex = "0";

            chkSpan = document.createElement("span")
            chkSpan.setAttribute("id", "CheckboxBorder");
            chkSpan.style.position = "relative";
            chkSpan.style.zIndex = "0";

            //chkSpan.setAttribute("style","left:0px;top:-0px;POSITION:relative")

            chkSpan.appendChild(chkBox);
            cell.appendChild(chkSpan);
            chkBox.checked = isSelectBoxChecked;

            chkBox.id = "sel_" + uniqueId;
            if (!inactive) {
                chkBox.onclick = function () {
                    if (window.QAChecked) {
                        QAChecked(uniqueId);
                    }

                    if (window.QAChecked2) {
                        QAChecked2(uniqueId, nodeName);
                    }
                    //cancelEvent(window.event)
                }
            }
        }
    }

    // Create the cell for the plus and minus.
    cell = document.createElement("TD");
    cell.setAttribute("width", 10);
    row.appendChild(cell);

    // Create the hyperlink for plus/minus the cell
    a = document.createElement("A");
    cell.appendChild(a);
    a.setAttribute("id", "P" + uniqueId);
    if (!inactive) {
        a.setAttribute("href", "javascript:Toggle(\"" + uniqueId + "\");");
    }

    //a.onmouseover = function () { var path = this.childNodes[0].getAttribute("src"); path = path.replace("plus.png", "plusOver.png"); path = path.replace("minus.png", "minusOver.png"); this.childNodes[0].setAttribute("src", path); }
    //a.onmouseout = function () { var path = this.childNodes[0].getAttribute("src"); path = path.replace("plusOver.png", "plus.png"); path = path.replace("minusOver.png", "minus.png"); this.childNodes[0].setAttribute("src", path); }

    if (hasChild)
        AddImage2(a, plusImagePath, 6, 8, 0);
    else
        AddImage2(a, transparentImagePath, 6, 8, 0);

    if (showPreviewIcon == true) {
        // Create the cell for the image.
        cell = document.createElement("TD");
        cell.setAttribute("width", 14);
        row.appendChild(cell);

        // Add the image to the cell
        var previewImg = AddImage2(cell, previewImagePath, 14, 14, 0);
        previewImg.onmouseover = function () { this.style.cursor = "Hand"; };
        previewImg.onmouseout = function () { this.style.cursor = "auto"; };
        previewImg.setAttribute("id" + "pre_" + uniqueId);
        previewImg.onclick = function () {
            if (window.PreviewQuestion) {
                PreviewQuestion(uniqueId);
            }
            cancelEvent(window.event)
        }

    }

    //// ------------- if Image is required after + sign
    //    // Create the cell for the image.
    //    cell = document.createElement("TD");
    //    cell.setAttribute("width", 16);
    //    row.appendChild(cell);

    //    // all the event to call when the icon is clicked.
    //    a = document.createElement("A");
    //    a.setAttribute("id", "I" + uniqueId);
    //    a.setAttribute("href", "javascript:Toggle(\"" + uniqueId + "\");");
    //    cell.appendChild(a);

    //    // Add the image to the cell
    //    AddImage(a, img1FileName);

    //// ------------- end of 'if Image is required after + sign'

    // Create the cell for the text
    cell = document.createElement("TD");
    cell.noWrap = true;
    a = document.createElement("A");
    //a.setAttribute("id", uniqueId);
    cell.appendChild(a);
    //	if( url != null )
    //	{
    //		a.setAttribute( "href", url );
    //		if( target != null )
    //			a.setAttribute( "target", target );
    //		else
    //			a.setAttribute( "target", "_blank" );
    //		
    //		text=document.createTextNode( nodeName );
    //		a.appendChild(text);
    //	}
    //	else
    //	{
    //		text=document.createTextNode( nodeName );
    //		cell.appendChild(text);
    //	}

    //text = document.createTextNode(nodeName);
    text = document.createElement("span")
    text.innerHTML = nodeName;
    text.setAttribute("id", "txt_" + uniqueId);

    if (inactive)
        text.style.color = "gray";
    cell.appendChild(text);

    cell.className = cssClass;
    Spacetext = document.createTextNode(" ");
    cell.appendChild(Spacetext);

    //var EditimgCreated = AddImage2(cell, editImagePath, 10,10,10,);
    //EditimgCreated.onclick = function () {
    text.onclick = function () {
        if (window.EditQuestionAnswer) {
            EditQuestionAnswer(uniqueId);
        }
        cancelEvent(window.event)
    }

    //text.setAttribute("title", "Click to edit");
    text.onmouseover = function () { this.style.cursor = "Hand"; if (window.ShowTooltip) { ShowTooltip("txt_" + uniqueId); } }
    text.onmouseout = function () { this.style.cursor = "auto"; if (window.HideTooltip) { HideTooltip("txt_" + uniqueId); } }

    Spacetext2 = document.createTextNode(" ");
    cell.appendChild(Spacetext2);

    if (ShowImageAhead) {
        var AddimgCreated = AddImage2(cell, addImagePath, 16, 8, 10);
        AddimgCreated.setAttribute("id" + "add_" + uniqueId);

        AddimgCreated.onmouseover = function () { this.style.cursor = "Hand"; };
        AddimgCreated.onmouseout = function () { this.style.cursor = "auto"; };

        AddimgCreated.onclick = function () {
            var div = document.getElementById("D" + uniqueId);
            var visible = (div.style.display != "none");
            if (!visible) { Toggle(uniqueId); }

            if (window.AddQuestionAnswer) {
                AddQuestionAnswer(uniqueId);
            }
            cancelEvent(window.event)
        }
    }
    row.appendChild(cell);


    spA = document.createElement("span")
    spA.innerHTML = "  ";
    spA.setAttribute("id", "spA_" + uniqueId);
    spA.setAttribute("paddingTop", "-10px");
    cell.appendChild(spA);
    spA.className = "Label";



    return CreateDiv(parent, uniqueId); ;
}



function cancelEvent(e) {
    e = e ? e : window.event;
    if (e.stopPropagation)
        e.stopPropagation();
    if (e.preventDefault)
        e.preventDefault();
    e.cancelBubble = true;
    e.cancel = true;
    e.returnValue = false;
    return false;
}

// Creates a new DIV tag and appends it to parent if parent is not null.
// Returns the new DIV tag.
function CreateDiv(parent, id) {
    div = document.createElement("DIV");
    if (parent != null)
        parent.appendChild(div);
    div.setAttribute("id", "D" + id);
    div.setAttribute("ChildPopulated", "0");
    div.style.display = "none";
    div.style.marginLeft = "4em";

    return div;
}

// This is the root of the tree. It must be supplied as the parent for anything at the top level of the tree.
var rootCell = null;

var mounseOverImagePath = null;
var plusImagePath = null;
var minusImagePath = null;
var transparentImagePath = null;

var addImagePath = null;
var editImagePath = null;

var previewImagePath = null;

// This is the entry method into the Tree View. It builds an initial single row, single cell table tat will 
// contain the tree. It initialises a global object "rootCell". This object must be used as the parent for all 
// top-level tree elements.
// There are two methods for creating tree elements: CreatePackage() and CreateNode(). The images for the 
// package are hard coded. CreateNode() allows you to supply your own image for each node element.
function Initialise(containerID, tableID, MouseOverImagePath, plusImage, minusImage, transparentImage, AddImagePath, EditImagePath, PreviewImagePath) {
    //body = document.getElementsByTagName("body").item(0);
    //body.setAttribute( "leftmargin", 2 );
    //body.setAttribute( "topmargin", 0 );
    //body.setAttribute( "marginwidth", 0 );
    //body.setAttribute( "marginheight", 0 );

    body = document.getElementById(containerID);

    table = document.createElement("TABLE");
    table.setAttribute("id", tableID);
    body.appendChild(table);

    table.setAttribute("border", 0);
    table.setAttribute("cellpadding", 1);
    table.setAttribute("cellspacing", 1);

    table.setAttribute("width", "100%");

    tablebody = document.createElement("TBODY");
    table.appendChild(tablebody);

    row = document.createElement("TR");
    tablebody.appendChild(row);

    cell = document.createElement("TD");
    row.appendChild(cell);


    rootCell = cell; // Initialise the root of the tree view.
    mounseOverImagePath = MouseOverImagePath;
    plusImagePath = plusImage;
    minusImagePath = minusImage;
    transparentImagePath = transparentImage;
    addImagePath = AddImagePath;
    editImagePath = EditImagePath;
    previewImagePath = PreviewImagePath;
}







document.onmousemove = mouseMove;
document.onmouseup = mouseUp;

var dragObject = null;
var mouseOffset = null;


function getMouseOffset(target, ev) {
    ev = ev || window.event;
    var docPos = getPosition(target);
    var mousePos = mouseCoords(ev);
    return { x: mousePos.x - docPos.x, y: mousePos.y - docPos.y };
}

function getPosition(e) {
    var left = 0;
    var top = 0;
    while (e.offsetParent) {
        left += e.offsetLeft;
        top += e.offsetTop;
        e = e.offsetParent;
    }

    left += e.offsetLeft;
    top += e.offsetTop;

    return { x: left, y: top };
}

function mouseMove(ev) {
    if (dragObject) {
        ev = ev || window.event;
        var mousePos = mouseCoords(ev);
        document.body.style.cursor = "move";
        //dragObject.style.display = "inline";
        //dragObject.style.position = 'absolute';
        //dragObject.style.top = mousePos.y - mouseOffset.y;
        //dragObject.style.left = mousePos.x - mouseOffset.x;

        return false;
    }
}
function mouseUp() {

    if (dragObject != null) {
        var obj = window.event.srcElement;
        if (obj) {
            if (obj.tagName == "IMG" || obj.tagName == "SPAN") {
                document.body.style.cursor = "auto";
                //dragObject.outerHTML = "";
                dragObject = null;
                return;
            }

            var tagName = obj.tagName;
            var dropppedTable
            if (tagName == "TD")
                dropppedTable = obj.parentNode.parentNode.parentNode;
            else if (tagName == "TR")
                dropppedTable = obj.parentNode.parentNode;
            else if (tagName == "TBODY")
                dropppedTable = obj.parentNode;
            else if (tagName == "TABLE")
                dropppedTable = obj;
            else {
                alert("Invalid element to drop");
                document.body.style.cursor = "auto";
                //dragObject.outerHTML = "";
                dragObject = null;
                return;
            }
            var droppedID = dropppedTable.getAttribute("id");
            droppedID = droppedID.substring(4); // eliminate "Tab_"                


            var draggedID = dragObject.id;
            //draggedID = draggedID.substring(12); // eliminate "FloatingTab_"
            draggedID = draggedID.substring(4); // eliminate "Tab_"


            if (draggedID == droppedID) {
                document.body.style.cursor = "auto";
                //dragObject.outerHTML = "";
                dragObject = null;
                return;
            }


            if (draggedID.substring(0, 2) == droppedID.substring(0, 2)) // level is same
            {

                var draggedTableobj = document.getElementById("Tab_" + draggedID)
                var parentID = draggedTableobj.getAttribute("parentID");
                var id = parentID.substring(1); // eliminate "D"                
                document.getElementById(parentID).innerHTML = "";
                var rtn = SwapChild(id, draggedID, droppedID) // method in form to retrieve child and popolate
                if (rtn == "0") // success
                {
                    document.getElementById(parentID).setAttribute("ChildPopulated", "1");
                    //removeIcon = false;
                }
                document.body.style.cursor = "auto";
                //dragObject.outerHTML = "";
                dragObject = null;

            }
            else {
                alert("drop level is not same");
                document.body.style.cursor = "auto";
                dragObject = null;
                return;
            }
        }
        document.body.style.cursor = "auto";
        dragObject = null;

    }
}

function makeDraggable(item) {
    if (!item) return;
    item.onmousedown = function (ev) {
        //var tmpTable = getTempTable(this)
        dragObject = this; //tmpTable;        
        mouseOffset = getMouseOffset(this, ev);
        return false;
    }
}

function getTempTable(createFrom) {

    uniqueId = createFrom.id.substring(4);  // eliminate Tab_
    var table = document.createElement("TABLE");
    createFrom.parentNode.appendChild(table);
    table.setAttribute("border", 0);
    table.setAttribute("cellpadding", 1);
    table.setAttribute("cellspacing", 1);
    table.setAttribute("width", "100%");
    table.setAttribute("id", "Floating" + createFrom.getAttribute("id"));
    table.style.display = "none";


    tablebody = document.createElement("TBODY");
    table.appendChild(tablebody);

    row = document.createElement("TR");
    tablebody.appendChild(row);

    // Create the cell for the plus and minus.
    cell = document.createElement("TD");
    cell.setAttribute("width", 16);
    row.appendChild(cell);

    // Create the hyperlink for plus/minus the cell

    AddImage(cell, transparentImagePath, 6, 8, 0);

    cell = document.createElement("TD");
    cell.noWrap = true;


    text = document.createElement("span")
    text.innerHTML = createFrom.innerText;
    cell.className = "Label";

    cell.appendChild(text);
    row.appendChild(cell);
    row.style.backgroundImage = "url(" + mounseOverImagePath + ")";

    return table;

}

function mouseCoords(ev) {
    if (ev.pageX || ev.pageY) {
        return { x: ev.pageX, y: ev.pageY };
    }
    return {
        x: ev.clientX + document.body.scrollLeft - document.body.clientLeft,
        y: ev.clientY + document.body.scrollTop - document.body.clientTop
    };
}









