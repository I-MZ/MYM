using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

/// <summary>
/// �O�ǂ̐F���d�͂̌����ɍ��킹�ĕύX����N���X
/// </summary>
public class WallColorChenger : MonoBehaviour
{
    //�X�e�[�W�̃^�C���}�b�v�擾
    [SerializeField] Tilemap tilemap = default;

    //�^�C���̃f�[�^�����Ă����z��
    [SerializeField] TileBase[] tiles;

    private PlayerController.GRAVITY Oldgravity;
    private bool Change;

    // Start is called before the first frame update
    void Start()
    {
        Oldgravity = PlayerController.instance.startgravity;
        Change = false;
    }

    // Update is called once per frame
    void Update()
    {
        CheckGravity();

        if (Change)
        {//�d�͂��ς������

            //�d�͂̌����ɍ��킹�ă^�C�������ւ���
            switch (PlayerController.instance.gravity) 
            {
                //��
                case PlayerController.GRAVITY.DOWN:
                    for (int i = 0; i < 10; i++)
                    {
                        tilemap.SwapTile(tiles[10 * 1 + i], tiles[10 * 0 + i]);
                        tilemap.SwapTile(tiles[10 * 2 + i], tiles[10 * 0 + i]);
                        tilemap.SwapTile(tiles[10 * 3 + i], tiles[10 * 0 + i]);
                    }
                    break;

                //��
                case PlayerController.GRAVITY.UP:
                    for (int i = 0; i < 10; i++)
                    {
                        tilemap.SwapTile(tiles[10 * 0 + i], tiles[10 * 1 + i]);
                        tilemap.SwapTile(tiles[10 * 2 + i], tiles[10 * 1 + i]);
                        tilemap.SwapTile(tiles[10 * 3 + i], tiles[10 * 1 + i]);
                    }
                    break;

                //�E
                case PlayerController.GRAVITY.RIGHT:
                    for (int i = 0; i < 10; i++)
                    {
                        tilemap.SwapTile(tiles[10 * 0 + i], tiles[10 * 2 + i]);
                        tilemap.SwapTile(tiles[10 * 1 + i], tiles[10 * 2 + i]);
                        tilemap.SwapTile(tiles[10 * 3 + i], tiles[10 * 2 + i]);
                    }
                    break;

                //��
                case PlayerController.GRAVITY.LEFT:
                    for (int i = 0; i < 10; i++)
                    {
                        tilemap.SwapTile(tiles[10 * 0 + i], tiles[10 * 3 + i]);
                        tilemap.SwapTile(tiles[10 * 1 + i], tiles[10 * 3 + i]);
                        tilemap.SwapTile(tiles[10 * 2 + i], tiles[10 * 3 + i]);
                    }
                    break;
            }

            Change = false;
        }
        
        //�d�͂̋���ɂ��ύX
        if (PlayerController.instance.forcepower)
        {//�d�͂��������
            //�F���Â�����
            tilemap.color = new Color(0.7f, 0.7f, 0.7f);
        }
        else
        {//�d�͂��ク���
            //�F��߂�
            tilemap.color = new Color(1.0f, 1.0f, 1.0f);
        }
        
    }

    /// <summary>
    /// �d�͂��ς���Ă��Ȃ������m�F����֐�
    /// </summary>
    void CheckGravity()
    {
        if (Oldgravity != PlayerController.instance.gravity)
        {
            Change = true;
            Oldgravity = PlayerController.instance.gravity;
        }
    }
}
