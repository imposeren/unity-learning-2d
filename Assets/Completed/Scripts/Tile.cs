using UnityEngine;
using System.Collections;


namespace Completed {
    public class Tile : MonoBehaviour {

        private bool isHovered;
        private Color hoverColor = new Color(0.572f, 0.96f, 1f);
        internal int x;
        internal int y;

        // Use this for initialization
        void Start() {

        }

        // Update is called once per frame
        void Update() {
            if (!GameManager.instance || !GameManager.instance.editingLevel) {
                return;
            }
            var spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
            if (this.isHovered) {
                spriteRenderer.color = this.hoverColor;
            } else {
                spriteRenderer.color = Color.white;
            }
        }

        void OnMouseEnter() {
            this.isHovered = true;
        }

        void OnMouseExit() {
            this.isHovered = false;
        }

        void OnMouseUpAsButton() {
            Debug.Log(string.Format("clicked {0}, {1}", this.x, this.y));
            if (!GameManager.instance.editingLevel) {
                return;
            }
            var board = GameManager.instance.GetComponent<BoardManager>();
            var food = board.foodTiles[Random.Range(0, board.foodTiles.Length)];
            if (this.gameObject.tag != "Exit") {
                board.LayoutObjectAtPosition(food, this.x, this.y);
            } else {
                GameManager.instance.editingLevel = false;
                GameManager.instance.playersTurn = true;
            }
        }
    }

}