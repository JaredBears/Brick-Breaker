using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Board : MonoBehaviour
{
    /* The prefab of the block, the number of blocks horizontally (columns) and vertically (rows),
        * and the size of the block to control spacing
        */
    [SerializeField] GameObject blockPrefab;
    [SerializeField] int columns;
    [SerializeField] int rows;
    [SerializeField] Vector2 blockSize;

    int blocksRemaining;
    public UnityEvent boardClearedEvent;
    
    // When a block is destroyed, decrement the number of blocks remaining
    void blocksDestroyed()
    {
        blocksRemaining--;
        // If there are no blocks remaining, invoke the board cleared event
        if (blocksRemaining == 0)
        {
            boardClearedEvent.Invoke();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Loop through the rows and columns to create the blocks
        for (int row = 0; row < rows; row++)
        {
            for (int column = 0; column < columns; column++)
            {
                // Instantiate the block and set its position
                var blockInstance = Instantiate(blockPrefab, transform);
                blockInstance.transform.SetParent(transform);
                blockInstance.transform.localPosition = new Vector3(column * blockSize.x, row * blockSize.y, 0);
                // Set the health of the block based on the row
                var block = blockInstance.GetComponent<Block>();
                block.health = Mathf.Clamp(row, 0, Block.maxHealth);
                // Add a listener to the block's destroyed event
                block.destroyedEvent.AddListener(blocksDestroyed);
            }
        }
        // Set the number of blocks remaining to the total number of blocks
        blocksRemaining = columns * rows;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
