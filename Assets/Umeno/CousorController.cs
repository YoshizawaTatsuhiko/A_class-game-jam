using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CousorController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // �}�E�X�J�[�\��������
        //Cursor.visible = false;
    }

    void Update()
    {
        // Camera.main �Ń��C���J�����iMainCamera �^�O�̕t���� Camera�j���擾����
        // Camera.ScreenToWorldPoint �֐��ŁA�X�N���[�����W�����[���h���W�ɕϊ�����
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //mousePosition.x = 0;    // Z ���W���J�����Ɠ����ɂȂ��Ă���̂ŁA���Z�b�g����
        this.transform.position = mousePosition;
    }
}
